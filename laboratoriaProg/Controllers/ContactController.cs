using laboratoriaProg.Models;
using Microsoft.AspNetCore.Mvc;

namespace laboratoriaProg.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1, new ContactModel()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Abecki",
                Email = "adam@wsei.edu.pl",
                BirthDate = new DateOnly(2000, 10, 10),
                PhoneNumber = "+48 222 333 555"
            }
        },
        {
            2, new ContactModel()
            {
                Id = 1,
                FirstName = "Karol",
                LastName = "Kowal",
                Email = "adam@wsei.edu.pl",
                BirthDate = new DateOnly(2000, 10, 10),
                PhoneNumber = "+48 222 333 555"
            }
        },
        {
            3, new ContactModel()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Mekowski",
                Email = "adam@wsei.edu.pl",
                BirthDate = new DateOnly(2000, 10, 10),
                PhoneNumber = "+48 222 333 555"
            }
        }

    };

    private static int currentId = 3;
    //Lista kontaktów
    public IActionResult Index()
    {
        return View(_contacts);
    }
    [HttpGet]
    //Formularz dodania kontaktu
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    //Odebranie i zapisanie nowego kontaktu
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = ++currentId;
        _contacts.Add(model.Id , model);
        return View("Index", _contacts);
        
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }
    
}