using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2025.Models;

namespace Projekt2025.Pages
{
    public class EventsModel : PageModel
    {

        private readonly Projekt2025.Models.fgonline_dk_db_zooContext _context;

        public EventsModel(Projekt2025.Models.fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        public List<Models.Event> Events { get; set; }
        public string TilmeldBesked { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
            
            //Viser Kun Kommende Events
            Events = _context.Events
                .Where(e => e.EventDateTimeEnd > DateTime.Now)
                .OrderBy(e => e.EventDateTimeStart)
                .ToList();
        }


        public IActionResult OnPostTilmeld(int eventId)
        {
            int memberId = 1;

            bool alreadyRegistread = _context.MemberEventList
                .Any(x => x.MemberID == memberId && x.EventID == eventId);

            if (!alreadyRegistread)
            {
                _context.MembereventList.Add(new MemberEventList
                {
                    MemberID = memberId,
                    EventID = eventId
                });
                _context.SaveChanges();

                TilmeldBesked = "Du er nu tilmeld denne event";
            }
            else
            {
                TilmeldBesked = "Du er allerede tilmeldt eventet";
            }

            Events = _context.Events.ToList();
            return Page();
        }

    }
}
