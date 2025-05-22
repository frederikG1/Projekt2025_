using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Projekt2025.Pages
{
    public class AabningstiderModel : PageModel
    {
        // Model til én dags åbningstid
        public class Aabningstid
        {
            public string Ugedag { get; set; } = "";
            public string Tid { get; set; } = "Lukket";
            public bool ErAaben => !Tid.ToLower().Contains("lukket");
        }

        // Listen med ugedage + tider
        public List<Aabningstid> Aabningstider { get; set; } = new();

        // Dagens dato (bruges til kalender, starter altid mandag)
        public DateTime StartDato { get; set; } =
            DateTime.Today.AddDays(-(int)(DateTime.Today.DayOfWeek + 6) % 7);

        public void OnGet()
        {
            // Ugedage og tider
            Aabningstider = new List<Aabningstid>
            {
                new Aabningstid { Ugedag = "Mandag", Tid = "12:00-16:00" },
                new Aabningstid { Ugedag = "Tirsdag", Tid = "12:00-16:00" },
                new Aabningstid { Ugedag = "Onsdag", Tid = "12:00-16:00" },
                new Aabningstid { Ugedag = "Torsdag", Tid = "12:00-16:00" },
                new Aabningstid { Ugedag = "Fredag", Tid = "14:00 - 17:00" },
                new Aabningstid { Ugedag = "Lørdag", Tid = "Lukket" },
                new Aabningstid { Ugedag = "Søndag", Tid = "Lukket" }
            };
        }
    }
}
