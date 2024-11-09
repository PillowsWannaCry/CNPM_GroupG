using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.Employee
{
    public class EditModel : PageModel
    {
        private readonly IKoiOrderEmployeeService _employeeService;
        private readonly IKoiOrderRoleService _roleService;

        public EditModel(IKoiOrderEmployeeService employeeService, IKoiOrderRoleService roleService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
        }

        [BindProperty]
        public KoiOrderEmployee KoiOrderEmployee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                return NotFound();
            }
            Id = (int)id;
            var koiOrderEmployee = await _employeeService.GetKoiOrderEmployeeById(Id);
            if (koiOrderEmployee == null)
            {
                return NotFound();
            }

            KoiOrderEmployee = koiOrderEmployee;

            var roles = await _roleService.GetAllRolesAsync();
            ViewData["RoleId"] = new SelectList(roles, "RoleId", "RoleName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var roles = await _roleService.GetAllRolesAsync();
                ViewData["RoleId"] = new SelectList(roles, "RoleId", "RoleName");
                return Page();
            }

            var updateResult = await _employeeService.UpdateKoiOrderEmployee(KoiOrderEmployee);

            if (!updateResult)
            {
                if (!await _employeeService.EmployeeExistsAsync(KoiOrderEmployee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Cập nhật nhân viên thất bại. Vui lòng thử lại.");
                    return Page();
                }
            }

            return RedirectToPage("./Index");

        }
    }
}
