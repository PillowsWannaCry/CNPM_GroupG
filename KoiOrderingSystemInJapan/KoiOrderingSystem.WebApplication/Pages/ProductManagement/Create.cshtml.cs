using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public CreateModel(IProductService productService , ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
                _supplierService = supplierService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var category = await _categoryService.GetAllCategoriesAsync();
            ViewData["CategoryId"] = new SelectList(category, "CategoryId", "Name");
            var supplier = await _supplierService.GetAllSuppliersAsync();
            ViewData["SupplierId"] = new SelectList(supplier, "SupplierId", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if  (await _productService.AddProductAsync(Product)) 
            {
                return RedirectToPage("./Index");
            }

            ModelState.AddModelError(string.Empty, "Không tạo được!");
            return Page();
        }
    }
}
