using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly IKoiOrderCustomerService _Service;

        public CreateModel(IKoiOrderCustomerService Service)
        {
            _Service = Service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KoiOrderCustomer KoiOrderCustomer { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }
            _Service.AddKoiOrderCustomer(KoiOrderCustomer);
            return RedirectToPage("./Index");
        }
    }
}
