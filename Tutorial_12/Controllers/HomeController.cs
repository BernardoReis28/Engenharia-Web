using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Tutorial_12.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tutorial_12.Controllers
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

        public string testAjax(string id)
        {
            //this section replaces a hypothetical access to a data repository (eg database) for consulting the information.
            Dictionary<string, List<string>> allCities = new Dictionary<string, List<string>>();
            allCities.Add("PT", new List<string>() { "Porto", "Lisboa", "Coimbra" });
            allCities.Add("ES", new List<string>() { "Madrid", "Valencia", "Sevilla" });
            allCities.Add("FR", new List<string>() { "Paris", "Lille", "Marseille" });

            List<string> itens = new List<string>();
            if (id != null && allCities.ContainsKey(id))
                itens = allCities[id];

            return JsonConvert.SerializeObject(itens);
        }


        public IActionResult Privacy()
        {
            List<string> allTags = new List<string> ();
            allTags.Add("Porto");
            allTags.Add("Lisboa");
            allTags.Add("Coimbra");
            allTags.Add("Madrid");
            allTags.Add("Valencia");
            allTags.Add("Sevílla");
            allTags.Add("Paris");
            allTags.Add("Lile");
            allTags.Add("Marseile");

            ViewBag.tags = new HtmlString(JsonConvert.SerializeObject(allTags.ToArray()));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}