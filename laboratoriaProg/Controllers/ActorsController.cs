using laboratoriaProg.Models.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ActorsController : Controller
{
    private readonly MoviesDatabase _context;

    public ActorsController(MoviesDatabase context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int page = 1, int size = 20)
    {
        int totalActors = await _context.People.CountAsync();
        ViewBag.TotalActors = totalActors;
        ViewBag.CurrentPage = page;
        ViewBag.PageSize = size;
        ViewBag.TotalPages = (int)Math.Ceiling((double)totalActors / size);

        var actors = await _context.People
            .OrderBy(a => a.PersonName)
            .Skip((page - 1) * size)
            .Take(size)
            .Select(a => new
            {
                a.PersonId,
                a.PersonName,
                MovieCount = _context.MovieCasts.Count(mc => mc.PersonId == a.PersonId) 
            })
            .ToListAsync();

        var actorIds = actors.Select(a => a.PersonId).ToList();
        var rolesDict = await _context.MovieCasts
            .Where(mc => actorIds.Contains((int)mc.PersonId))
            .Select(mc => new { mc.PersonId, mc.CharacterName })
            .ToListAsync();

        var groupedRoles = rolesDict
            .GroupBy(mc => mc.PersonId)
            .ToDictionary(g => g.Key, g => g.Select(mc => mc.CharacterName).ToList());

        var actorsWithRoles = actors.Select(a => new
        {
            a.PersonId,
            a.PersonName,
            a.MovieCount,
            Roles = groupedRoles.ContainsKey(a.PersonId) ? groupedRoles[a.PersonId] : new List<string>() 
        }).ToList();

        return View(actorsWithRoles);
    }
    
    public async Task<IActionResult> Movies(int actorId, int page = 1, int size = 20)
    {
        if (actorId <= 0) return BadRequest("Actor ID is required.");
        if (page < 1 || size <= 0) return BadRequest("Invalid pagination parameters.");

        var actor = await _context.People.FirstOrDefaultAsync(p => p.PersonId == actorId);
        if (actor == null) return NotFound("Actor not found.");

        int totalMovies = await _context.MovieCasts.CountAsync(mc => mc.PersonId == actorId);
        int totalPages = (int)Math.Ceiling((double)totalMovies / size);

        var movies = await _context.MovieCasts
            .Where(mc => mc.PersonId == actorId)
            .Include(mc => mc.Movie)
            .OrderByDescending(mc => mc.Movie.Popularity)
            .Skip((page - 1) * size)
            .Take(size)
            .Select(mc => mc.Movie)
            .AsNoTracking()
            .ToListAsync();

        ViewBag.ActorId = actorId;
        ViewBag.ActorName = actor.PersonName;
        ViewBag.TotalMovies = totalMovies;
        ViewBag.CurrentPage = page;
        ViewBag.PageSize = size;
        ViewBag.TotalPages = totalPages;

        return View(movies);
    }

    // ✅ [GET] Add movie form for an actor
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> AddMovie(int actorId)
    {
        if (actorId <= 0) return BadRequest("Actor ID is required.");

        var actor = await _context.People.FirstOrDefaultAsync(p => p.PersonId == actorId);
        if (actor == null) return NotFound("Actor not found.");

        ViewBag.ActorId = actorId;
        ViewBag.ActorName = actor.PersonName;
        ViewBag.Movies = await _context.Movies
            .OrderBy(m => m.Title)
            .Select(m => new SelectListItem { Value = m.MovieId.ToString(), Text = m.Title })
            .ToListAsync();

        return View();
    }

    // ✅ [POST] Handle adding a movie for an actor
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddMovie(int actorId, int movieId, string characterName)
    {
        if (actorId <= 0) return BadRequest("Actor ID is required.");

        var actor = await _context.People.FirstOrDefaultAsync(p => p.PersonId == actorId);
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == movieId);

        if (actor == null || movie == null) return NotFound("Actor or movie not found.");

        var newMovieCast = new MovieCast
        {
            PersonId = actorId,
            MovieId = movieId,
            CharacterName = characterName
        };

        _context.MovieCasts.Add(newMovieCast);
        await _context.SaveChangesAsync();

        return RedirectToAction("Movies", new { actorId });
    }
}
