using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.OrderManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiOrderService _service;

        public DeleteModel(IKoiOrderService service)
        {
            _service = service;
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
            else
            {
                Order = order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _service.DeleteOrderAsync(id.Value);
            if (!order)
            {
                ModelState.AddModelError(string.Empty, "Không xóa được nhân viên. Vui lòng thử lại.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
