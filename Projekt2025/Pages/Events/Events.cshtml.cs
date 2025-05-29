using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2025.Models;

namespace Projekt2025.Pages
{
    public class EventsModel : PageModel
    {
        private readonly fgonline_dk_db_zooContext _context;

        public EventsModel(fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        public int? TilmeldtEventId { get; set; }
        public List<Event> Events { get; set; } = new();
        public string? TilmeldBesked { get; set; } 

        public async Task OnGetAsync()
        {
            Events = await _context.Events
                .Where(e => e.EventDateTimeEnd > DateTime.Now)
                .OrderBy(e => e.EventDateTimeStart)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostTilmeldAsync(int eventId)
        {

        // Henter MemberId fra brugerens seassion 
            int? memberId = HttpContext.Session.GetInt32("MemberID");
        
        // Hvis bruger ikke logget ind vil memberId. En TilmeldBesked blev vist 

            if (memberId == null)
            {
                TilmeldBesked = "Du skal være logget ind for at tilmelde dig.";
                await OnGetAsync(); 
                return Page();
            }

        // Finder MemberId fra databasen 
            var member = await _context.Members
                .Include(m => m.Events)
                .FirstOrDefaultAsync(m => m.MemberId == memberId.Value);


        // Finder det event brugeren vil tilmelde 
            var selectedEvent = await _context.Events.FindAsync(eventId);

        // Tjekker om Member og Event er blevet fundet, hvis ikke, bliver Tilmeldbesked vist 
            if (member == null || selectedEvent == null)
            {
                TilmeldBesked = "Bruger eller event kunne ikke findes.";
            }
        // Tilføer eventet til MemberEventList og en TilmeldBesked bliver vist
            else if (!member.Events.Any(e => e.EventId == eventId))
            {
                member.Events.Add(selectedEvent);
                await _context.SaveChangesAsync();
                TilmeldBesked = "Du er nu tilmeldt denne event.";
            }
            else
            {
                TilmeldBesked = "Du er allerede tilmeldt eventet.";
            }

            TilmeldtEventId = eventId;

            await OnGetAsync(); 

            return Page();
        }
    }
}
