using laboratoriaProg.Models;
using laboratoriaProg.Models.Identity;
using laboratoriaProg.Models.Movies;
using laboratoriaProg.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MoviesDatabase>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MoviesDatabase")));

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("IdentityContextConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ContactsDatabase")));

builder.Services.AddTransient<IContactService, EFContactService>();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        builder.Configuration.GetSection("Authentication:Password").Bind(options.Password);
        options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Authentication:RequireConfirmedAccount");
    })
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); 

app.Run();