using Microsoft.AspNetCore.Mvc;

namespace laboratoriaProg.Controllers;

public class CalculatorController : Controller
{
    [HttpPost]
    public IActionResult Result(Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    [HttpGet]
    public IActionResult Result(Operator2? operator2, double? x, double? y)
    {
        if (x == null || y == null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby a lub liczby b";
            return View("CustomError");
        }

        if (!operator2.HasValue)
        {
            ViewBag.ErrorMessage = "Nieznany operator.";
            return View("Calculator");
        }

        ViewBag.Op = operator2;
        ViewBag.A = x;
        ViewBag.B = y;

        switch (operator2)
        {
            case Operator2.Add:
                ViewBag.Result = x + y;
                ViewBag.Operator = "+";
                break;
            case Operator2.Sub:
                ViewBag.Result = x - y;
                ViewBag.Operator = "-";
                break;
            case Operator2.Mul:
                ViewBag.Result = x * y;
                ViewBag.Operator = "*";
                break;
            case Operator2.Div:
                if (y == 0)
                {
                    ViewBag.ErrorMessage = "Nie można dzielić przez zero.";
                    return View("CustomError");
                }
                ViewBag.Result = x / y;
                ViewBag.Operator = "/";
                break;
            default:
                ViewBag.ErrorMessage = "Nieznany operator.";
                return View("CustomError");
        }

        return View();
    }
    
    public IActionResult Form()
    {
        return View();
    }
}
public enum Operator2
{
    Unknown, Add, Mul, Sub, Div
}   