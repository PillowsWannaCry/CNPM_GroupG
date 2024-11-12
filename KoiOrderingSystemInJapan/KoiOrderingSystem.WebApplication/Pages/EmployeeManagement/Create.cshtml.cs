using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem.Repositories.Entities;

namespace KoiOrderingSystem.WebApplication.Pages.EmployeeManagement
{
    public class CreateModel : PageModel
    {
        private readonly KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext _context;

        public CreateModel(KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public KoiOrderEmployee KoiOrderEmployee { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.KoiOrderEmployees.Add(KoiOrderEmployee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
