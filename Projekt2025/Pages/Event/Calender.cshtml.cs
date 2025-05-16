using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2025.Models;

namespace Projekt2025.Pages.Event
{
    public class CalenderModel : PageModel
    {
            private readonly fgonline_dk_db_zooContext _context;

            public CalenderModel(fgonline_dk_db_zooContext context)
            {
                _context = context;
            }

            public List<Models.Event> Events { get; set; }

            public async Task OnGetAsync()
            {
                Events = await _context.Events.ToListAsync();
            }

    }
}
