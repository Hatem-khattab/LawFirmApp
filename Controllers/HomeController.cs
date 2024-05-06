using LawFirmApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LawFirmApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult File()
        {
            return View();
        }
        public IActionResult Case()
        {
            return View();
        }
        public IActionResult Courts()
        {
            return View();
        }
        //public IActionResult SaveLawyer()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
