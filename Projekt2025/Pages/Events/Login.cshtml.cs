using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2025.Models;

namespace Projekt2025.Pages.Events;

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

    public async Task<IActionResult> OnPostAsync()
    //Query til at finde member ud fra email
    {
        var member = await(
            from m in _context.Members
            where m.Email == Email
            select m
        ).FirstOrDefaultAsync();

        if (member == null)
        {
            Message = "No member found with that email.";
            return Page();
        }

        //Rykker info mellem "sessions", tænker det er den samme session med redicrect til en anden page, så vi kan bruge info fra en side til en anden!
        HttpContext.Session.SetInt32("MemberID", member.MemberId);
        return RedirectToPage("MyEvents");
    }
}
