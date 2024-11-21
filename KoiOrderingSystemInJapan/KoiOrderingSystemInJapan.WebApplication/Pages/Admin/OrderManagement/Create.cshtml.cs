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

namespace KoiOrderingSystem.WebApplication.Pages.OrderManagement
{
    public class CreateModel : PageModel
    {
        private readonly IKoiOrderService _service;
        private readonly KoiOrderCustomerService _Customerservice;

        public CreateModel(IKoiOrderService service, KoiOrderCustomerService Customerservice)
        {
            _service = service;
            _Customerservice = Customerservice;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy danh sách tất cả khách hàng từ dịch vụ
            var customers = await _Customerservice.KoiOrderCustomers();

            // Tạo danh sách dropdown từ kết quả
            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "Name");

            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Lấy lại danh sách khách hàng để hiển thị nếu có lỗi
                var customers = await _Customerservice.KoiOrderCustomers();
                ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "Name");

                return Page();
            }

            // Thêm đơn hàng qua dịch vụ
            var result = await _service.AddOrderAsync(Order);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Thêm đơn hàng thất bại. Vui lòng thử lại.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
