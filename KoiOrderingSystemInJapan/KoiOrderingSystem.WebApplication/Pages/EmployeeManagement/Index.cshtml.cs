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
    public class IndexModel : PageModel
    {
        private readonly KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext _context;

        public IndexModel(KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public IList<KoiOrderEmployee> KoiOrderEmployee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            KoiOrderEmployee = await _context.KoiOrderEmployees
                .Include(k => k.Role).ToListAsync();
        }
    }
}
