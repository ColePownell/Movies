using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Models;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using System;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly MovieDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public HomeController(ILogger<HomeController> logger, MovieDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}

        public IActionResult Index()
        {
            var movies = _context.Movies;
			return View(movies);
		}

        public IActionResult AboutusCole()
        {
            return View();
        }
		public IActionResult AboutusYifan()
		{
			return View();
		}
		public IActionResult AboutusChelsea()
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

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(Movie movie)
		{
			if (ModelState.IsValid)
			{
				if (movie.PosterFile != null)
				{
					string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
					string uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.PosterFile.FileName;
					string filePath = Path.Combine(uploadsFolder, uniqueFileName);
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						await movie.PosterFile.CopyToAsync(fileStream);
					}
					movie.Poster = "/images/" + uniqueFileName;
				}
				_context.Movies.Add(movie);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(movie);
		}


		[HttpGet]
		public IActionResult Edit(int id)
		{
			var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
			if (movie == null)
			{
				return NotFound();
			}
			return View(movie);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Movie movie)
		{
			if (id != movie.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				// Handle file upload
				if (movie.PosterFile != null && movie.PosterFile.Length > 0)
				{
					string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images");
					string uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.PosterFile.FileName;
					string filePath = Path.Combine(uploadDir, uniqueFileName);
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						await movie.PosterFile.CopyToAsync(fileStream);
					}
					movie.Poster = "/images/" + uniqueFileName;
				}

				_context.Update(movie);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(movie);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
			if (movie != null)
			{
				_context.Movies.Remove(movie);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return NotFound();
		}
	}
}
