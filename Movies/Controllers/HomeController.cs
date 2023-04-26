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

		public IActionResult Login()
		{
			return View();
		}

		public ActionResult Register()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		[HttpPost]
		public IActionResult Login(UserModel model)
		{
			var user = _context.UserModels.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
			if (user != null)
			{
				user.SessionId = HttpContext.Session.Id;
				_context.SaveChanges();

				HttpContext.Session.SetInt32("UserId", user.UserId);
				HttpContext.Session.SetString("SessionId", user.SessionId);
				HttpContext.Session.SetString("Username", user.Username);

				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("", "Invalid username or password.");
				return View(model);
			}
		}

		[HttpPost]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public IActionResult Register(UserModel model)
		{
			if (ModelState.IsValid)
			{
				var existingUser = _context.UserModels.FirstOrDefault(u => u.Username == model.Username);
				if (existingUser != null)
				{
					ModelState.AddModelError("Username", "Username already exists.");
				}
				else
				{
					var user = new UserModel
					{
						Username = model.Username,
						Password = model.Password,
						ConfirmPassword = model.ConfirmPassword,
						Email = model.Email
					};

					_context.UserModels.Add(user);
					_context.SaveChanges();

					return RedirectToAction("Login", "Home");
				}
			}

			return View(model);
		}

	}
}
