using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystemInJapan.WebApplication.Pages.FeedbackManagement
{
    public class CreateModel : PageModel
    {
        private readonly IFeedbackService _sevice;

        public CreateModel(IFeedbackService service)
        {
            _sevice = service;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            //ViewData["CustomerId"] = new SelectList(_context.KoiOrderCustomers, "CustomerId", "Username");
            //ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "Name");
            var customers = await _sevice.GetCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "Username");
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

            _sevice.AddFeedbackAsync(Feedback);
            return RedirectToPage("./Index");
        }
    }
}
