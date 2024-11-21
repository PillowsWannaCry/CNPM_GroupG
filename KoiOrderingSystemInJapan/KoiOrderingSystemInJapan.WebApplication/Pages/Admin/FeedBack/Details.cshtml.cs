using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;

namespace KoiOrderingSystemInJapan.WebApplication.Pages.Admin.FeedBack
{
    public class DetailsModel : PageModel
    {
        private readonly KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext _context;

        public DetailsModel(KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (feedback == null)
            {
                return NotFound();
            }
            else
            {
                Feedback = feedback;
            }
            return Page();
        }
    }
}
