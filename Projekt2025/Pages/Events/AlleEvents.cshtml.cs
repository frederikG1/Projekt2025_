using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Projekt2025.Pages
{
    public class AlleEventsModel : PageModel
    {

        private readonly Projekt2025.Models.fgonline_dk_db_zooContext _context;

        public AlleEventsModel(Projekt2025.Models.fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        public List<Models.Event> Events { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
        
        //Viser Alle Events
            Events = _context.Events
                .OrderBy(e => e.EventDateTimeStart)
                .ToList();
        }

      
    }
}
