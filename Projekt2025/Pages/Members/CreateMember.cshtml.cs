using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projekt2025.Models;

namespace Projekt2025.Pages
{
    public class MemberModel : PageModel
    {
        private readonly fgonline_dk_db_zooContext _context;

        public MemberModel(fgonline_dk_db_zooContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Member member { get; set; }

        [BindProperty]
        public Login login { get; set; }

        // Liste som bruges til at kunne vælge de forskellige studieretninger
        public List<SelectListItem> studyProgram { get; set; }

        // Bliver kaldt når Membersiden indlæses, og laver en .Select som minder om for-each, som gør vi kan vise alle studieretninger
        public void OnGet()
        {
            studyProgram = _context.StudyPrograms
                .Select(s => new SelectListItem
                {
                    Value = s.StudyId.ToString(),
                    Text = s.Name
                }).ToList();// skal reloade når der laves fejl i kodeord
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                OnGet();
                return Page();
            }

            if (_context.Logins.Any(l => l.Username == login.Username))
            {
                ModelState.AddModelError("login.Username", "Dette brugernavn er allerede i brug.");
                OnGet(); // Husk dropdown
                return Page();
            }

            if (string.IsNullOrWhiteSpace(login.Password) ||
                login.Password.Length < 8 ||
                !login.Password.Any(char.IsUpper) ||
                !login.Password.Any(char.IsLower) ||
                !login.Password.Any(char.IsDigit))
            {
                ModelState.AddModelError("login.Password","Adgangskoden skal være mindst 8 tegn, og indeholde mindst ét stort bogstav, ét lille bogstav og ét tal."); 
                return Page();
            }
        

            try
            {
                //Tilføjer og gemmer Member i databasen
                _context.Members.Add(member);
                _context.SaveChanges();

                //Tilføjer og gemmer Login i Databasen
                login.MemberId = member.MemberId;
                _context.Logins.Add(login);
                _context.SaveChanges();

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Fejl under oprettelse: {ex.Message}");
                OnGet();
                return Page();
            }
        }
    }
}
