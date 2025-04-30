using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt2025.Pages.AdminUser
{
    public class AdminDashboardModel : PageModel
    {
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("/AdminUser/AdminUser");
        }
        
        public void OnGet()
        {
        }
    }
}
