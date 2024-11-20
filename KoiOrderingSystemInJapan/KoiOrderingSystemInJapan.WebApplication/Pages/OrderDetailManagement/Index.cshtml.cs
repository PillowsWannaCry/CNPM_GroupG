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
    public class IndexModel : PageModel
    {
        private readonly IKoiOrderDetailService _service;

        public IndexModel(IKoiOrderDetailService service)
        {
            _service = service;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderDetail = await _service.GetAllOrderDetailsAsync();
        }
    }
}
