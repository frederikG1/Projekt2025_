using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2025.Models;

namespace Projekt2025.Pages.Event
{
    public class EventModel : PageModel
    {
        private readonly Projekt2025.Models.fgonline_dk_db_zooContext _context;

        public EventModel(Projekt2025.Models.fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        public List<Models.Event> Events { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
        }

    }
}
