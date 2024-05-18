using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tutorial_10.Models;
using Tutorial_10.Filtros;

namespace Tutorial_10.Controllers
{
    [DailyMaintenanceFilter(From = new[] {23,0,0}, To = new[] {0,0,0})]

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
