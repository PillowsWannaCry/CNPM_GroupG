using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem.Repositories.Entities;

namespace KoiOrderingSystem.WebApplication.Pages.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext _context;

        public CreateModel(KoiOrderingSystem.Repositories.Entities.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
