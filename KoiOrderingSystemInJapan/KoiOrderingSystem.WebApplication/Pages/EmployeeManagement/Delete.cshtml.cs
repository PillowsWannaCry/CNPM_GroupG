using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.EmployeeManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiOrderEmployeeService _service;

        public DeleteModel(IKoiOrderEmployeeService service)
        {
            _service = service;
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var success = await _service.DeleteEmployeeAsync(id.Value);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Không xóa được nhân viên. Vui lòng thử lại.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
