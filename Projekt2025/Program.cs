using Microsoft.EntityFrameworkCore;
using Projekt2025.Interfaces;
using Projekt2025.Models;
using Projekt2025.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(); // ✅ enable session support

builder.Services.AddDbContext<fgonline_dk_db_zooContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IMember, MemberService>();
builder.Services.AddScoped<IAdmin, AdminService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/AdminUser/AdminUser";
        options.LogoutPath = "/AdminUser/AdminUser";
        options.AccessDeniedPath = "/AdminUser/AdminUser";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseSession();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
