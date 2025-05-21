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

    public Member Member { get; set; }

    public List<Models.Event> Events { get; set; } = new();

    //tjekker vi for en id værdi, hvis den er null returner den pagen.
    public async Task<IActionResult> OnGetAsync()
    {
        int? memberId = HttpContext.Session.GetInt32("MemberID");

        if (memberId == null)
        {
            return Page(); 
        }

        //SQL query til at finde given member og alle events der er linket til memberen.
        Member = await (
            from m in _context.Members
            where m.MemberId == memberId
            select m
        ).Include(m => m.Events).FirstOrDefaultAsync();

        //tjekker om der er en member og events, laver en normal liste der er nemmere at loade, ellers retuner en tom liste for at undgå fejl
        if (Member != null && Member.Events != null)
        {
            Events = Member.Events.ToList();
        }
        else
        {
            Events = new List<Event>();
        }

        return Page();
    }
}
