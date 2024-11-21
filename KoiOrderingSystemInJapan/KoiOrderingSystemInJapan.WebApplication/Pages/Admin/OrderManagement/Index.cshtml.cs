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
    public class IndexModel : PageModel
    {
        private readonly IKoiOrderService _service;

        public IndexModel(IKoiOrderService service)
        {
            _service = service;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _service.GetAllOrdersAsync();
        }
    }
}
