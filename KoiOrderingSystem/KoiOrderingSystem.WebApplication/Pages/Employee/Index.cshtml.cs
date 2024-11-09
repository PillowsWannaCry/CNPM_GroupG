using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly IKoiOrderEmployeeService   _service;

        public IndexModel(IKoiOrderEmployeeService service)
        {
            _service                = service;
        }

        public IList<KoiOrderEmployee> KoiOrderEmployee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            KoiOrderEmployee = await _service.KoiOrderEmployees().Include(k => k.Role).ToListAsync();
        }
    }
}
