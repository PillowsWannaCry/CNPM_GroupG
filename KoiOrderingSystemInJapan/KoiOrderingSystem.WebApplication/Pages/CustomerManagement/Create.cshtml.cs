using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.CustomerManagement
{
    public class CreateModel : PageModel
    {
        private readonly IKoiOrderCustomerService   _service;

        public CreateModel(IKoiOrderCustomerService service)
        {
            _service = service;
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

            _service.AddKoiOrderCustomer(KoiOrderCustomer);

            return RedirectToPage("./Index");
        }
    }
}
