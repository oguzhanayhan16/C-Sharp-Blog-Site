using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false; // En az bir büyük harf
    x.Password.RequiredLength = 1;
}).AddEntityFrameworkStores<Context>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Oturum, GDPR uyumluluðu için gereklidir.
});

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireRole("Admin") // Admin rolüne sahip olmayanlarý reddet
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithRedirects("/Login/AccessDenied"); // Yetkilendirme hatalarýný yönlendir
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();


