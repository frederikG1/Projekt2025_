using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventKalender.Pages
{
    public class EventKalenderModel : PageModel
    {
        public class Begivenhed
        {
            public string Titel { get; set; } = "";
            public string? Beskrivelse { get; set; }
            public DateTime DatoTid { get; set; }
        }

        public static List<Begivenhed> Begivenheder = new();

        [BindProperty]
        public string? Titel { get; set; }

        [BindProperty]
        public string? Beskrivelse { get; set; }

        [BindProperty]
        public DateTime? DatoTid { get; set; }

        public void OnGet() { }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(Titel) && DatoTid.HasValue)
            {
                Begivenheder.Add(new Begivenhed
                {
                    Titel = Titel,
                    Beskrivelse = Beskrivelse,
                    DatoTid = DatoTid.Value
                });
            }
        }

        public IActionResult OnPostSlet(int index)
        {
            if (index >= 0 && index < Begivenheder.Count)
            {
                Begivenheder.RemoveAt(index);
            }
            return RedirectToPage();
        }
    }
}
