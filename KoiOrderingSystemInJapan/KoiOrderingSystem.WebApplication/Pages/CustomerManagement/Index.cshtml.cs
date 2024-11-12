using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.CustomerManagement
{
    public class IndexModel : PageModel
    {
        private readonly IKoiOrderCustomerService _Service;

        public IndexModel(IKoiOrderCustomerService Service)
        {
            _Service = Service;
        }

        public IList<KoiOrderCustomer> KoiOrderCustomer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            KoiOrderCustomer = await _Service.KoiOrderCustomers();
        }
    }
}