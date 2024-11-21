using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystemInJapan.WebApplication.Pages.FeedbackManagement
{
    public class IndexModel : PageModel
    {
        private readonly IFeedbackService _service;

        public IndexModel(IFeedbackService service)
        {
            _service = service;
        }

        public IList<Feedback> Feedback { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Feedback = await _service.Feedbacks()
                .Include(f => f.Customer)
                .Include(f => f.Tour).ToListAsync();
        }
    }
}
