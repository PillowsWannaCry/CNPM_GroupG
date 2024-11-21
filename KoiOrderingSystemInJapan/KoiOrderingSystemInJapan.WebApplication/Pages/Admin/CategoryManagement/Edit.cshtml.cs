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

namespace KoiOrderingSystemInJapan.WebApplication.Pages.CategoryManagement
{
    public class EditModel : PageModel
    {
        private readonly ICategoryService _service;

        public EditModel(ICategoryService service)
        {
            _service = service;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _service.GetCategoryByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = _service.UpdateCategoryAsync(Category);
            if (res == null)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
