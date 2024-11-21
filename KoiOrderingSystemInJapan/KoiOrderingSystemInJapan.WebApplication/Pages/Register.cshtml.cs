using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiOrderingSystem.WebApplication.Pages
{
    public class RegisterModel : PageModel
    {

        private readonly IKoiOrderEmployeeService _service;
        private readonly IKoiOrderRoleService _roleService;

        public RegisterModel(IKoiOrderEmployeeService service, IKoiOrderRoleService roleService)
        {
            _service = service;
            _roleService = roleService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var roles = await _roleService.GetAllRolesAsync();
            ViewData["RoleId"] = new SelectList(roles, "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public KoiOrderEmployee KoiOrderEmployee { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                var roles = await _roleService.GetAllRolesAsync();
                ViewData["RoleId"] = new SelectList(roles, "RoleId", "RoleName");
                return Page();
            }


            var result = await _service.AddEmployeeAsync(KoiOrderEmployee);

            if (result)
            {

                return RedirectToPage("./Index");
            }
            else
            {

                ModelState.AddModelError(string.Empty, "Không th? thêm nhân viên. Vui l?ng th? l?i.");

                var roles = await _roleService.GetAllRolesAsync();
                ViewData["RoleId"] = new SelectList(roles, "RoleId", "RoleName");
                return Page();
            }

        }
    }
}
