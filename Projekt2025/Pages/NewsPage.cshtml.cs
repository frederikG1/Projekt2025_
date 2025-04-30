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

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            ModelState.AddModelError("Email", "Email is required.");
            return Page();
        }

        //
        bool exists = (from sub in _context.NewsletterSubs
                       where sub.Email == Email
                       select sub).Any();

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
