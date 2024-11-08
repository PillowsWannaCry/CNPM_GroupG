using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.WebApplication.Pages.Employee
{
    public class CreateModel : PageModel
    {
        private readonly IKoiOrderEmployeeService _service;
        private readonly KoiOrderingSystemContext _context; 

        public CreateModel(IKoiOrderEmployeeService service, KoiOrderingSystemContext context)
        {
            _service = service;
            _context = context;
        }

        [BindProperty]
        public KoiOrderEmployee KoiOrderEmployee { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            var result = await _service.AddKoiOrderEmployee(KoiOrderEmployee);

            if (result)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Không thể thêm nhân viên. Vui lòng thử lại.");
                return Page();
            }
        }
    }
}
