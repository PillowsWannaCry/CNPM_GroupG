using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.Employee
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiOrderEmployeeService   _service;

        public DetailsModel(IKoiOrderEmployeeService service)
        {
            _service = service;
        }

        public KoiOrderEmployee KoiOrderEmployee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                return NotFound();
            }
            Id = (int)id;
            var koiorderemployee = await _service.GetKoiOrderEmployeeById(Id);
            if (koiorderemployee == null)
            {
                return NotFound();
            }
            else
            {
                KoiOrderEmployee = koiorderemployee;
            }
            return Page();
        }
    }
}
