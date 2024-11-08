using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiOrderCustomerService _Service;

        public DetailsModel(IKoiOrderCustomerService Service)
        {
            _Service = Service;
        }

        public KoiOrderCustomer KoiOrderCustomer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                return NotFound();
            }
            Id = (int)id;
            var koiordercustomer = await _Service.GetKoiOrderCustomerById(Id);
            if (koiordercustomer == null)
            {
                return NotFound();
            }
            else
            {
                KoiOrderCustomer = koiordercustomer;
            }
            return Page();
        }
    }
}
