using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystemInJapan.WebApplication.Pages.CategoryManagement
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _service;

        public IndexModel(ICategoryService service)
        {
            _service = service;
        }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _service.Categories();
        }
    }
}
