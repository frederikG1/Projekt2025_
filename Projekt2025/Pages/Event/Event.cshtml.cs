using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt2025.Pages.Event
{
    public class EventModel : PageModel
    {
        private readonly Projekt2025.Models.fgonline_dk_db_zooContext _context;.

        public EventModel(Projekt2025.Models.fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        public List<Event> Event { get; set; } = default!;
        public void OnGet()
        {
        }
    }
}
