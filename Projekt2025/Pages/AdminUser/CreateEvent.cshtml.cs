using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt2025.Models;

namespace Projekt2025.Pages.AdminUser
{
    public class CreateEventModel : PageModel
    {
        private readonly Projekt2025.Models.fgonline_dk_db_zooContext _context;

        public CreateEventModel(Projekt2025.Models.fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("AdminDashboard");
        }
    }
}
