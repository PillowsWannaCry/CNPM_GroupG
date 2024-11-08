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
    public class EditModel : PageModel
    {
        private readonly IKoiOrderCustomerService _service;

        public EditModel(IKoiOrderCustomerService service)
        {
            _service = service;
        }

        [BindProperty]
        public KoiOrderCustomer KoiOrderCustomer { get; set; } = default!;

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); 
            }

            
            var koiordercustomer = await _service.GetKoiOrderCustomerById(id.Value);

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

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            
            var result = _service.UpdateKoiOrderCustomer(KoiOrderCustomer);

            if (!result)
            {
               
                return NotFound();
            }

            
            return RedirectToPage("./Index");
        }
    }
}
