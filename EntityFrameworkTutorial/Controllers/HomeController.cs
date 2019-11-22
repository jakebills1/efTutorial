using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntityFrameworkTutorial.Models;
using EntityFrameworkTutorial;
using EntityFrameworkTutorial.Data;

namespace EntityFrameworkTutorial.Controllers
{
    public class HomeController : Controller
    {
        // the controller is constructed every time a http request comes in
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // checks to see if database exists, if not creates it
            _context.Database.EnsureCreated();

            // if there are no rows in the Settings Table
            if (!_context.Settings.Any())
            {
                var dm = new SettingsDataModel { Name = "BackgroundColor", Value = "Red", Id = _context.Id };

                _context.Settings.Add(dm);

                var localSettings = _context.Settings.Local.Count();
                var remoteSettings = _context.Settings.Count();

                var firstLocal = _context.Settings.Local.FirstOrDefault();
                var firstRemote = _context.Settings.FirstOrDefault();
                _context.SaveChanges();
                localSettings = _context.Settings.Local.Count();
                remoteSettings = _context.Settings.Count();

                firstLocal = _context.Settings.Local.FirstOrDefault();
                firstRemote = _context.Settings.FirstOrDefault();



            }
            return View();
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
