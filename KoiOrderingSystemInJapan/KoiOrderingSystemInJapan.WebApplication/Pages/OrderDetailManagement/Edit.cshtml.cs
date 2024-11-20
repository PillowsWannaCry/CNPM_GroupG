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

namespace KoiOrderingSystemInJapan.WebApplication.Pages.OrderDetailManagement
{
    public class EditModel : PageModel
    {
        private readonly IKoiOrderDetailService _service;
        private readonly IKoiOrderService _Orderservice;
        private readonly ProductService _Productservice;
        public EditModel(IKoiOrderDetailService service, IKoiOrderService Orderservice, ProductService Productservice)
        {
            _service = service;
            _Orderservice = Orderservice;
            _Productservice = Productservice;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _service.GetOrderDetailByIdAsync(id.Value);
            if (orderdetail == null)
            {
                return NotFound();
            }


            OrderDetail = orderdetail;
            var order = await _Orderservice.GetAllOrdersAsync();
            ViewData["OrderId"] = new SelectList(order, "OrderId", "Status");

            var products = await _Productservice.Products().ToListAsync();
            ViewData["ProductId"] = new SelectList(products, "ProductId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
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

            var updateResult = await _service.UpdateOrderDetailAsync(OrderDetail);

            if (!updateResult)
            {
                // Nếu cập nhật thất bại, hiển thị thông báo lỗi
                ModelState.AddModelError(string.Empty, "Cập nhật chi tiết đơn hàng thất bại. Vui lòng thử lại.");

                // Lấy lại danh sách đơn hàng và sản phẩm
                var orders = await _Orderservice.GetAllOrdersAsync();
                ViewData["OrderId"] = new SelectList(orders, "OrderId", "Status");

                var products = await _Productservice.Products().ToListAsync();
                ViewData["ProductId"] = new SelectList(products, "ProductId", "Name");

                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}
