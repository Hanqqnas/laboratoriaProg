using laboratoriaProg.Models;
using laboratoriaProg.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace laboratoriaProg.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    //Lista kontaktów
    public IActionResult Index()
    {
        return View(_contactService.GetAll());
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
        _contactService.Add(model);
        return RedirectToAction(nameof(Index));

    }
    public ActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
    }
    [HttpGet]
    public ActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }
    [HttpPost]
    public ActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _contactService.Update(model);
        return RedirectToAction(nameof(System.Index));

    }
    public IActionResult Delete(int id)
    {
        var contact = _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}