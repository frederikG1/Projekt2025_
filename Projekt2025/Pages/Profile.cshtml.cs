using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2025.Models;

namespace Projekt2025.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly fgonline_dk_db_zooContext _context;

        public ProfileModel(fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        public Member CurrentMember { get; set; }

        public IActionResult OnGet()
        {
            var memberId = HttpContext.Session.GetInt32("MemberId");

            if (memberId == null)
            {
                return RedirectToPage("/Index");
            }

            //Sørger for at det er den korrekte member information, som findes på siden. m.study henter studyprogram, da den er en Class for sig selv.
            CurrentMember = _context.Members
                .Include(m => m.Study)
                .Where(m => m.MemberId == memberId)
                .FirstOrDefault();

            if (CurrentMember == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

    }
}
