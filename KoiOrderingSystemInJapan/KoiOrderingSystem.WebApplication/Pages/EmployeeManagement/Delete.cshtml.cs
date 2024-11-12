using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;

namespace KoiOrderingSystem.WebApplication.Pages.EmployeeManagement
{
    public class DeleteModel : PageModel
    {
        private readonly KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext _context;

        public DeleteModel(KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KoiOrderEmployee KoiOrderEmployee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koiorderemployee = await _context.KoiOrderEmployees.FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (koiorderemployee == null)
            {
                return NotFound();
            }
            else
            {
                KoiOrderEmployee = koiorderemployee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koiorderemployee = await _context.KoiOrderEmployees.FindAsync(id);
            if (koiorderemployee != null)
            {
                KoiOrderEmployee = koiorderemployee;
                _context.KoiOrderEmployees.Remove(KoiOrderEmployee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
