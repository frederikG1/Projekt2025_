using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2025.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekt2025.Pages
{
    public class EventKalenderModel : PageModel
    {
        private readonly fgonline_dk_db_zooContext _context;

        public EventKalenderModel(fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        public List<Event> KommendeEvents { get; set; } = new();

        // Kalenderen starter altid på mandag
        public DateTime StartDato { get; set; } =
            DateTime.Today.AddDays(-(int)(DateTime.Today.DayOfWeek + 6) % 7);

        public void OnGet()
        {
            var slutDato = StartDato.AddDays(28); // 4 uger frem

            KommendeEvents = _context.Events
                .Where(e => e.EventDateTimeStart >= StartDato && e.EventDateTimeStart <= slutDato)
                .OrderBy(e => e.EventDateTimeStart)
                .ToList();
        }
    }
}
