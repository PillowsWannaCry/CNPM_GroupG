using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem.Repositories.Entities;

namespace KoiOrderingSystemInJapan.WebApplication.Pages.Admin.FeedBack
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
        ViewData["CustomerId"] = new SelectList(_context.KoiOrderCustomers, "CustomerId", "Password");
        ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "Name");
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Feedbacks.Add(Feedback);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
