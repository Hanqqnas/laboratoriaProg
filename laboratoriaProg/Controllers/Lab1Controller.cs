using Microsoft.AspNetCore.Mvc;

namespace laboratoriaProg.Controllers;

public class Lab1Controller : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Calculator(Operator? op, double? a, double? b)
    {
        if (a == null || b == null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby a lub liczby b";
            return View("CustomError");
        }

        if (!op.HasValue)
        {
            ViewBag.ErrorMessage = "Nieznany operator.";
            return View("Calculator");
        }

        ViewBag.Op = op;
        ViewBag.A = a;
        ViewBag.B = b;

        switch (op)
        {
            case Operator.Add:
                ViewBag.Result = a + b;
                ViewBag.Operator = "+";
                break;
            case Operator.Sub:
                ViewBag.Result = a - b;
                ViewBag.Operator = "-";
                break;
            case Operator.Mul:
                ViewBag.Result = a * b;
                ViewBag.Operator = "*";
                break;
            case Operator.Div:
                if (b == 0)
                {
                    ViewBag.ErrorMessage = "Nie można dzielić przez zero.";
                    return View("CustomError");
                }
                ViewBag.Result = a / b;
                ViewBag.Operator = "/";
                break;
            default:
                ViewBag.ErrorMessage = "Nieznany operator.";
                return View("CustomError");
        }

        return View();
    }
    public int Age(DateTime birth, DateTime future)
    {
        if (birth > future)
        {
            throw new ArgumentException("Data urodzenia musi być wcześniej niż data future");
        }
        int age = future.Year - birth.Year;
        if (future < birth.AddYears(age))
        {
            age--;
        }
        
        return age;
    }

    public IActionResult AgeCalculator(DateTime birth, DateTime future)
    {
        try
        {
            int age = Age(birth, future);
            ViewBag.Age = age;
            return View(age);
        }
        catch (ArgumentException ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }
    
}
public enum Operator
{
    Unknown, Add, Mul, Sub, Div
}   