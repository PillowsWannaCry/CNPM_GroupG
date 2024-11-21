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
    public class DetailsModel : PageModel
    {
        private readonly ICategoryService _service;

        public DetailsModel(ICategoryService service)
        {
            _service = service;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                return NotFound();
            }
            Id = (int)id;
            var category = await _service.GetCategoryByIdAsync(Id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category; ;
            }
            return Page();
        }
    }
}

