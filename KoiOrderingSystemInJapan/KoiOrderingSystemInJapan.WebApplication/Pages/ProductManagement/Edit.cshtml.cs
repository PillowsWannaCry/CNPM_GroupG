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
using KoiOrderingSystem.Services;

namespace KoiOrderingSystem.WebApplication.Pages.ProductManagement
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService  _supplierService;

        public EditModel(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;  
            _categoryService = categoryService;
            _supplierService = supplierService; 
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;


            var category = await _categoryService.GetAllCategoriesAsync();
            ViewData["CategoryId"] = new SelectList(category, "CategoryId", "Name");
            var supplier = await _supplierService.GetAllSuppliersAsync();
            ViewData["SupplierId"] = new SelectList(supplier, "SupplierId", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var category = await _categoryService.GetAllCategoriesAsync();
                ViewData["CategoryId"] = new SelectList(category, "CategoryId", "Name");
                var supplier = await _supplierService.GetAllSuppliersAsync();
                ViewData["SupplierId"] = new SelectList(supplier, "SupplierId", "Name");
                return Page();
            }

            var updateResult = await _productService.UpdateProductAsync(Product);

            if (!updateResult)
            {
                if (!await _productService.ProductExistsAsync(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Cập nhật thất bại. Vui lòng thử lại.");
                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }

        
    }
}
