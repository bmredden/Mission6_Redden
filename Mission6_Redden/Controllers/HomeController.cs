using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Redden.Models;
using Mission6_Redden.Data;


namespace Mission6_Redden.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var movies = _context.Movies.ToList();
        return View(movies);
    }
    
    public IActionResult About()
    {
        return View();
    }

    // GET: AddMovie Form
    public IActionResult AddMovie()
    {
        return View();
    }
    
    [HttpPost] 
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            TempData["MovieAdded"] = "true";
            return RedirectToAction("Index"); 
        }
        return View(movie);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}