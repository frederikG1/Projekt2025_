using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2025.Interfaces;
using System.Collections.Generic;
using Projekt2025.Models;

namespace Projekt2025.Pages.AdminUser
{
    public class AdminDashboardModel : PageModel
    {
        private readonly fgonline_dk_db_zooContext _context;
        private readonly IAdmin _adminService;
        public AdminDashboardModel(IAdmin adminService, fgonline_dk_db_zooContext context)
        {
            _adminService = adminService;
            _context = context;
        }

        public IEnumerable<Event> Events { get; set; }

        public void OnGet()
        {
            Events = _adminService.GetEvents();
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/AdminUser/AdminUser");
        }
        
        
    }
}
