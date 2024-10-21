using laboratoriaProg.Models;
using Microsoft.AspNetCore.Mvc;

namespace laboratoriaProg.Controllers;

public class BirthController : Controller
{
    [HttpGet]
    public IActionResult Form()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Result(Birth model)
    {
        if (!model.IsValid())
        {
            ViewBag.ErrorMessage = "Podaj poprawne dane";
            return View("Form");
        }

        ViewBag.Name = model.Name;
        ViewBag.Age = model.CalculateAge();
        return View(model);
    }
}