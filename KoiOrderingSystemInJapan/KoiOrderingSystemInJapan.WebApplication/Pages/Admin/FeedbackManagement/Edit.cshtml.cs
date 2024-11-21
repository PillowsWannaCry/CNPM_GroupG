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

namespace KoiOrderingSystemInJapan.WebApplication.Pages.FeedbackManagement
{
    public class EditModel : PageModel
    {
        private readonly IFeedbackService _service;

        public EditModel(IFeedbackService service)
        {
            _service = service;
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _service.GetFeedbackById(id.Value);
            if (feedback == null)
            {
                return NotFound();
            }
            Feedback = feedback;
            //ViewData["CustomerId"] = new SelectList(_context.KoiOrderCustomers, "CustomerId", "Password");
            //ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "Name");
            var customers = await _service.GetCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "Username");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // thêm lại dữ liệu vào viewbag nếu model không hợp lệ
                var feedbacks = await _service.GetCustomers();
                ViewData["CustomerId"] = new SelectList(feedbacks, "CustomerId", "Username");
                return Page();
            }

            var res = _service.UpdateFeedbackAsync(Feedback);

            if (res == null)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}

