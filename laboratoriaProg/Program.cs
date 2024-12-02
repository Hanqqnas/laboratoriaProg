using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using laboratoriaProg.Models;
using laboratoriaProg.Models.Services;
using laboratoriaProg.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();                       
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>() 
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IContactService, EFContactService>();

builder.Services.AddMemoryCache();                     
builder.Services.AddSession();                      
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();                             
app.UseAuthorization();                               
app.UseSession();                                      
app.MapRazorPages();                                    
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();