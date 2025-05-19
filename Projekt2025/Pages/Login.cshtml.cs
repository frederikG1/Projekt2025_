using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2025.Models;

namespace Projekt2025.Pages;

public class LoginModel : PageModel
{
    private readonly fgonline_dk_db_zooContext _context;

    public LoginModel(fgonline_dk_db_zooContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string Email { get; set; }

    public string Message { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        var member = _context.Members.FirstOrDefault(m => m.Email == Email);

        if (member == null)
        {
            Message = "No member found with that email.";
            return Page();
        }

        HttpContext.Session.SetInt32("MemberID", member.MemberId);
        return RedirectToPage("/MyEvents");
    }
}
