using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2025.Interfaces;
using Projekt2025.Models;
using System.Collections.Generic;

namespace Projekt2025.Pages.AdminUser
{
    public class AdminDashboardModel : PageModel
    {
        private readonly fgonline_dk_db_zooContext _context;
        public AdminDashboardModel(IAdmin adminService, fgonline_dk_db_zooContext context)
        {
            _adminService = adminService;
            _context = context;
        }

        private readonly IAdmin _adminService;

        public IEnumerable<Event> Events { get; set; }

        public void OnGet()
        {
            Events = _adminService.GetEvents();
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("/AdminUser/AdminUser");
        }
        
        
    }
}
