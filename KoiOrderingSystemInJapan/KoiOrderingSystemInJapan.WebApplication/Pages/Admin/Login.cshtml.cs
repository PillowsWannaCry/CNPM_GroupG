using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using KoiOrderingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.WebApplication.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IKoiOrderEmployeeService _employeeService;

        public LoginModel(IKoiOrderEmployeeService employeeService)
        {
            _employeeService = employeeService;
            Input = new InputModel(); 
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public void OnGet()
        {
            ErrorMessage = string.Empty; 
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var employee = await _employeeService.KoiOrderEmployees()
                .FirstOrDefaultAsync(e => e.Username == Input.Username && e.Password == Input.Password);

            if (employee == null || employee.RoleId != 1) 
            {
                ErrorMessage = "Invalid username, password, or insufficient permissions.";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, employee.Username),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("EmployeeId", employee.EmployeeId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, 
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToPage("/Admin/Index");
        }
    }
}
