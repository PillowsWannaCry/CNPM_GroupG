using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.EmployeeManagement
{
    public class EditModel : PageModel
    {
        private readonly IKoiOrderEmployeeService _service;
        private readonly IKoiOrderRoleService _roleService;

        public EditModel(IKoiOrderEmployeeService service, IKoiOrderRoleService roleService)
        {
            _service = service;
            _roleService = roleService;
        }

        [BindProperty]
        public KoiOrderEmployee KoiOrderEmployee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koiorderemployee = await _service.GetEmployeeByIdAsync(id.Value);
            if (koiorderemployee == null)
            {
                return NotFound();
            }
            KoiOrderEmployee = koiorderemployee;
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

            var updateResult = await _service.UpdateEmployeeAsync(KoiOrderEmployee);

            if (!updateResult)
            {
                if (!await _service.EmployeeExistsAsync(KoiOrderEmployee.EmployeeId))
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
