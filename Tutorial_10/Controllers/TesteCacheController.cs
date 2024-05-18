using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial_10.Controllers
{
    public class TesteCacheController : Controller
    {
        [ResponseCache(Duration =20,Location =ResponseCacheLocation.Client)]

        public IActionResult OnClient()
        {
            return View();
        }

        [ResponseCache(Duration = 400, Location = ResponseCacheLocation.Any)]

        public IActionResult OnDownStream()
        {
            return View();
        }

        [ResponseCache(CacheProfileName="TestCacheProfile")]

        public IActionResult WithHeaders() 
        {
            return View();
        }
    }
}
