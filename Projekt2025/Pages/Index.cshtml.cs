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
    

    public IActionResult OnPost()
    {
        var user = _context.Logins
            .FirstOrDefault(l => l.Username == login.Username && l.Password == login.Password);

        if (user != null)
        {
            HttpContext.Session.SetInt32("MemberId", user.MemberId);
            HttpContext.Session.SetString("Username", user.Username);
            return RedirectToPage("/Profile");
        }

        LoginError = "Forkert brugernavn eller adgangskode";
        return Page();
    }



}
