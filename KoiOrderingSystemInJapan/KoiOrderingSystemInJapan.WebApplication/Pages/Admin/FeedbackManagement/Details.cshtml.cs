﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiOrderingSystemInJapan.WebApplication.Pages.FeedbackManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IFeedbackService _service;

        public DetailsModel(IFeedbackService service)
        {
            _service = service;
        }

        public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)id;
            var feedback = await _service.GetFeedbackById(Id);
            if (feedback == null)
            {
                return NotFound();
            }
            else
            {
                Feedback = feedback;
            }
            var customers = await _service.GetCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "Username");

            return Page();
        }
    }
}
