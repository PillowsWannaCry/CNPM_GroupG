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
    public class IndexModel : PageModel
    {
        private readonly KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext _context;

        public IndexModel(KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public IList<Feedback> Feedback { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Feedback = await _context.Feedbacks
                .Include(f => f.Customer)
                .Include(f => f.Tour).ToListAsync();
        }
    }
}
