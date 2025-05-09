using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2025.Models;

namespace Projekt2025.Pages.MemberPages;

public class MyEventsModel : PageModel
{
    private readonly fgonline_dk_db_zooContext _context;

    public MyEventsModel(fgonline_dk_db_zooContext context)
    {
        _context = context;
    }

    public Member? Member { get; set; }

    public List<Event> Events { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        int? memberId = HttpContext.Session.GetInt32("MemberID");

        if (memberId == null)
        {
            return Page(); 
        }

        Member = await _context.Members
            .Include(m => m.Events)
            .FirstOrDefaultAsync(m => m.MemberId == memberId);

        Events = Member?.Events.ToList() ?? new List<Event>();
        return Page();
    }

    public IActionResult OnPost(int setMember)
    {
        HttpContext.Session.SetInt32("MemberID", setMember);
        return RedirectToPage(); 
    }
}
