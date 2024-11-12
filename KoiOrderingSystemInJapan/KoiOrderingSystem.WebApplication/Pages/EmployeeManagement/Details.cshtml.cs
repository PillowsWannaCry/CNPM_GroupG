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
    public class DetailsModel : PageModel
    {
        private readonly KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext _context;

        public DetailsModel(KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext context)
        {
            _context = context;
        }

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
    }
}
