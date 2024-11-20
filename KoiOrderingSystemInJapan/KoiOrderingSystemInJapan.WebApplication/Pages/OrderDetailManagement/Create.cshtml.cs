using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;
using KoiOrderingSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.WebApplication.Pages.OrderDetailManagement
{
    public class CreateModel : PageModel
    {

        private readonly IKoiOrderDetailService _service;
        private readonly IKoiOrderService _Orderservice;
        private readonly ProductService _Productservice;

        public CreateModel(IKoiOrderDetailService service, IKoiOrderService Orderservice, ProductService Productservice)
        {
            _service = service;
            _Orderservice = Orderservice;
            _Productservice = Productservice;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var order = await _Orderservice.GetAllOrdersAsync();
            ViewData["OrderId"] = new SelectList(order, "OrderId", "Status");

            var products = await _Productservice.Products().ToListAsync();
            ViewData["ProductId"] = new SelectList(products, "ProductId", "Name");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var order = await _Orderservice.GetAllOrdersAsync();
                ViewData["OrderId"] = new SelectList(order, "OrderId", "Status");

                var products = await _Productservice.Products().ToListAsync();
                ViewData["ProductId"] = new SelectList(products, "ProductId", "Name");
                return Page();
            }

            var result = await _service.AddOrderDetailAsync(OrderDetail);

            if (result)
            {

                return RedirectToPage("./Index");
            }
            else
            {

                ModelState.AddModelError(string.Empty, "Không thể thêm nhân viên. Vui lòng thử lại.");

                var order = await _Orderservice.GetAllOrdersAsync();
                ViewData["OrderId"] = new SelectList(order, "OrderId", "Status");

                var products = await _Productservice.Products().ToListAsync();
                ViewData["ProductId"] = new SelectList(products, "ProductId", "Name");
                return Page();
            }
        }
    }
}
