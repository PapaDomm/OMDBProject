using Microsoft.AspNetCore.Mvc;
using OMDBProject.Models;
using System.Diagnostics;

namespace OMDBProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieSearch(string moviename)
        {
            MovieModel movie = MovieDAL.getMovie(moviename);
            return View(movie);
        }

        [HttpGet]
        public IActionResult MovieNight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieNight(string moviename1, string moviename2, string moviename3)
        {
            List<MovieModel> movies = new List<MovieModel>();
            movies.Add(MovieDAL.getMovie(moviename1));
            movies.Add(MovieDAL.getMovie(moviename2));
            movies.Add(MovieDAL.getMovie(moviename3));
            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
