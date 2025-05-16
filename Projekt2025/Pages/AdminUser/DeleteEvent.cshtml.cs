using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2025.Models;

namespace Projekt2025.Pages.AdminUser
{
    public class DeleteEventModel : PageModel
    {
        private readonly Projekt2025.Models.fgonline_dk_db_zooContext _context;

        public DeleteEventModel(Projekt2025.Models.fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventEntity = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);

            if (eventEntity is not null)
            {
                Event = eventEntity;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity != null)
            {
                Event = eventEntity;
                _context.Events.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("AdminDashboard");
        }
    }
}
