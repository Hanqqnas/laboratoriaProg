var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "laboratorium1",
    pattern: "lab1/{action=Index}/{id?}",
    defaults: new { controller = "Lab1" });

app.MapControllerRoute(
    name: "calculateAge",
    pattern: "Laboratorium1/AgeCalculator",
    defaults: new { controller = "Laboratorium1", action = "AgeCalculator" });

app.MapControllerRoute(
    name: "calculator",
    pattern: "Calculator/{action=Form}/{id?}",
    defaults: new { controller = "Calculator" });

app.MapControllerRoute(
    name: "birth",
    pattern: "Birth/{action=Form}/{id?}",
    defaults: new { controller = "Birth" }); // Nowa trasa dla BirthController

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();