using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Models;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly MovieDbContext _context;

		public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
			_context = context;
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Aboutus()
        {
            return View();
        }

        public IActionResult Directors()
        {
			List<Director> directors;
			directors = _context.Directors.ToList();
            return View(directors);
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

	}
}
