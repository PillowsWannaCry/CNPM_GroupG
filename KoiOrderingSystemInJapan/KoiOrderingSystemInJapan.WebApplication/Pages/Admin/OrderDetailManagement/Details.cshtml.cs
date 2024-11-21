using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystemInJapan.WebApplication.Pages.OrderDetailManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiOrderDetailService _service;

        public DetailsModel(IKoiOrderDetailService service)
        {
            _service = service;
        }

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
            else
            {
                OrderDetail = orderdetail;
            }
            return Page();
        }
    }
}
