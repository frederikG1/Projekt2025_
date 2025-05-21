using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2025.Models;

namespace Projekt2025.Pages.NewsPage;

public class IndexModel : PageModel
{
    private readonly fgonline_dk_db_zooContext _context;

    public IndexModel(fgonline_dk_db_zooContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string Email { get; set; }

    public string Message { get; set; }

    //har brugt Async da det er det "rigtige" at g�re, hvis siden skal bruges rigtigt of databasen for flere request p� en gang.
    public async Task<IActionResult> OnPostAsync()
    {
        //tjekker bare om der er skrevet noget i feltet, kunne godt v�re mere fuldg�rende med regex s� vi kan se om det 100% er en mail.
        if (string.IsNullOrWhiteSpace(Email))
        {
            ModelState.AddModelError("Email", "Email is required.");
            return Page();
        }

        //Laver et SQL kald der tjekker om en mail allerede er i databasen, og hvis ja, s�t exists til true.
        bool exists = (from sub in _context.NewsletterSubs
                       where sub.Email == Email
                       select sub).Any();

        //S� hvis mailen(exists) er false, s� s�t den p� databasen sammen med givet tidspunktet. Ellers giv besked til brugen om de allerede er tilmeldt.
        if (!exists)
        {
            var newSub = new NewsletterSub
            {
                Email = Email,
                SubscribedAt = DateTime.UtcNow
            };

            _context.NewsletterSubs.Add(newSub);
            await _context.SaveChangesAsync();

            Message = "Du er nu tilmedlt";
        }
        else
        {
            Message = "Du er allerede tilmeldt";
        }

        return Page();
    }
}
