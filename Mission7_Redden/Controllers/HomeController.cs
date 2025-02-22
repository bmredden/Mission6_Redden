using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission7_Redden.Data;
using Mission7_Redden.Models;

namespace Mission7_Redden.Controllers
{
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
            return View();
        }

        // Updated: Now includes Category data
        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(m => m.Category)  // Load Category data
                .ToList();  

            return View(movies);
        }

        public IActionResult About()
        {
            return View();
        }

        // Display AddMovie Form with Categories Dropdown
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.ToList();  //  Load categories
            return View();
        }

        //  Save Movie to Database
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                TempData["MovieAdded"] = "true";
                return RedirectToAction("MovieList");
            }

            ViewBag.Categories = _context.Categories.ToList();  //  Re-load categories if validation fails
            return View(movie);
        }

        //  Display Edit Movie Form with Categories
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();  //  Load categories
            return View(movie);
        }

        //  Save Edited Movie to Database
        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            ViewBag.Categories = _context.Categories.ToList();  // Re-load categories if validation fails
            return View(movie);
        }

        // Delete Movie
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
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
}
