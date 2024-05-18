using Microsoft.AspNetCore.Mvc;

namespace Tutorial_10.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Maintenance()
        {
            HttpContext.Response.StatusCode = 405;
            return View();
        }
    }
}
