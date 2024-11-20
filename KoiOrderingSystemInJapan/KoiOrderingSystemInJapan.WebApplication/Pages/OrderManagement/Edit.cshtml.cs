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

namespace KoiOrderingSystem.WebApplication.Pages.OrderManagement
{
    public class EditModel : PageModel
    {
        private readonly IKoiOrderService _service;
        private readonly KoiOrderCustomerService _Customerservice;

        public EditModel(IKoiOrderService service, KoiOrderCustomerService Customerservice)
        {
            _service = service;
            _Customerservice = Customerservice;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _service.GetOrderByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;


            var customers = await _Customerservice.KoiOrderCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var customers = await _Customerservice.KoiOrderCustomers();
                ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "Name");
                return Page();
            }

            var result = await _service.UpdateOrderAsync(Order);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật đơn hàng thất bại. Vui lòng thử lại.");

                // Tải lại danh sách khách hàng nếu lỗi
                var customers = await _Customerservice.KoiOrderCustomers();
                ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "Name");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
