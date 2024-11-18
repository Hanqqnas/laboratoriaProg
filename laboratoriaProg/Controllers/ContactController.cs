using laboratoriaProg.Models;
using laboratoriaProg.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        ContactModel model = new ContactModel();
        model.Organizations = _contactService
            .GetOrganizations()
            .Select(i => new SelectListItem()
            { 
                Value = i.Id.ToString(),
                Text = i.Name,
                Selected = i.Id == 1
            })
            .ToList();
        return View(model);
        
    }
    [HttpPost]
    //Odebranie i zapisanie nowego kontaktu
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Organizations = GetOrganizationsSelectList();
            return View(model);
        }
        _contactService.Add(model);
        return RedirectToAction(nameof(Index));
    }
    public ActionResult Details(int id)
    { 
        var contact = _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }
    [HttpGet]
    public ActionResult Edit(int id)
    {
        var contact = _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }
        contact.Organizations = GetOrganizationsSelectList();
        return View(contact);
    }
    [HttpPost]
    public ActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Organizations = GetOrganizationsSelectList();
            return View(model);
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
        var contact = _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }

        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    
    private List<SelectListItem> GetOrganizationsSelectList()
    {
        return _contactService.GetOrganizations()
            .Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            })
            .ToList();    }

}