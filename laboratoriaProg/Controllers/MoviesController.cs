using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using laboratoriaProg.Models.Movies;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class MoviesController : Controller
{
    private readonly MoviesDatabase _context;

    public MoviesController(MoviesDatabase context)
    {
        _context = context;
    }
    [Authorize]
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Movies = new SelectList(_context.Movies.OrderBy(m => m.Title), "MovieId", "Title");
        ViewBag.Actors = new SelectList(_context.People.OrderBy(p => p.PersonName), "PersonId", "PersonName");
        return View();
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MovieCast model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Movies = new SelectList(_context.Movies.OrderBy(m => m.Title), "MovieId", "Title");
            ViewBag.Actors = new SelectList(_context.People.OrderBy(p => p.PersonName), "PersonId", "PersonName");
            return View(model);
        }

        try
        {
            var movieExists = await _context.Movies.AnyAsync(m => m.MovieId == model.MovieId);
            var personExists = await _context.People.AnyAsync(p => p.PersonId == model.PersonId);

            if (!movieExists || !personExists)
            {
                ModelState.AddModelError("", "Wybrany film lub aktor nie istnieje.");
                return View(model);
            }

            _context.MovieCasts.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Movies", "Actors", new { actorId = model.PersonId });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Błąd: {ex.Message}");
            return View(model);
        }
    }

}