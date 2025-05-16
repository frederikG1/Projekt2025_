using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2025.Models;

namespace Projekt2025.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly fgonline_dk_db_zooContext _context;

    public IndexModel(fgonline_dk_db_zooContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }



    [BindProperty]
    public Login login { get; set; }

    public string LoginError { get; set; }
    public void OnGet()
    {

    }


    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var bruger = _context.Logins
            .FirstOrDefault(l => l.Username == login.Username && l.Password == login.Password);

        if (bruger != null)
        {
            // Her kunne du fx gemme bruger i session og redirecte
            return RedirectToPage("/MemberArea"); // ændr til din ønskede side
        }

        LoginError = "Forkert brugernavn eller adgangskode.";
        return Page(); // vis fejl
    }
}
