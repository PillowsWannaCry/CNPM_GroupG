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

namespace KoiOrderingSystem.WebApplication.Pages.CustomerManagement
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
            int Id = 0;
            if (id == null)
            {
                return NotFound();
            }
            Id = (int)id;
            var koiordercustomer = await _service.GetKoiOrderCustomerById(Id);
            if (koiordercustomer == null)
            {
                return NotFound();
            }
            KoiOrderCustomer = koiordercustomer;
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _service.UpdateKoiOrderCustomer(KoiOrderCustomer);

           
            return RedirectToPage("./Index");
        }

    }
}
