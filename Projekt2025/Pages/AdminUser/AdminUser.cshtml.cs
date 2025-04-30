using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt2025.Pages.AdminUser
{
    public class AdminUserModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        //hardcoded admin login 
        private readonly string AdminUsername = "admin";
        private readonly string AdminPassword = "admin123";

        public IActionResult OnPostLogin()
        {
            if (Username == AdminUsername && Password == AdminPassword)
            {
                return RedirectToPage("/AdminUser/AdminDashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page();
            }
        }


        public void OnGet()
        {
        }
    }
}
