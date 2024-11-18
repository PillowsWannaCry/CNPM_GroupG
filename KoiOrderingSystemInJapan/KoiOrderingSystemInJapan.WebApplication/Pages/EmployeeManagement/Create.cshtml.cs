using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;
using System.Data;

namespace KoiOrderingSystem.WebApplication.Pages.EmployeeManagement
{
    public class CreateModel : PageModel
    {
        private readonly IKoiOrderEmployeeService _service;
        private readonly IKoiOrderRoleService _roleService;

        public CreateModel(IKoiOrderEmployeeService service, IKoiOrderRoleService roleService)
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
                
                ModelState.AddModelError(string.Empty, "Không thể thêm nhân viên. Vui lòng thử lại.");
                
                var roles = await _roleService.GetAllRolesAsync();
                ViewData["RoleId"] = new SelectList(roles, "RoleId", "RoleName");
                return Page();
            }

        }
    }
}
