using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using Tutorial_03.Models;
using System.Xml.Linq;

namespace Tutorial_03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _he;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment e)
        {
            _logger = logger;
            _he = e;
        }

        //public IActionResult Index()
        //{
        //    DocFiles files = new DocFiles();

        //    return View(files.GetFiles(_he));
        //}

        public IActionResult Index()
        {
            // get the information of the files in the Documents folder ...
            // ... using the class Docfiles
            DocFiles files = new DocFiles();

            List<FileViewModel> myList = files.GetFiles(_he);

            // homework
            ViewBag.howManyFiles = myList.Count;
            //ViewData["howManyFiles"] = myList.Count;
            ViewBag.howMuchBytes = myList.Sum(x => x.Size);
            //ViewData["howMuchBytes"] = myList.Sum(x => x.Size);
            // homework

            return View(myList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Upload(IFormFile Name)
        //{
        //    // other file properties could be checked here, but we assume everiting is OK
        //    //
        //    if (ModelState.IsValid)
        //    {
        //        string destination = Path.Combine(_he.ContentRootPath,
        //            "wwwroot/Documents/", Path.GetFileName(Name.FileName));

        //        // creates a filestream to stoer the file bytes
        //        FileStream fs = new FileStream(destination, FileMode.Create);
        //        Name.CopyTo(fs);
        //        fs.Close();

        //        //after saving fle, redirects to file listing
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

        public IActionResult Upload(List<IFormFile> Name) // homework
        {
            // other file properties could be checked here, but we assume everything is OK

            if (ModelState.IsValid)
            {
                foreach (IFormFile _file in Name)
                {
                    string destination = Path.Combine(_he.ContentRootPath,
                         "wwwroot/Documents", Path.GetFileName(_file.FileName)
                        );

                    // creates a filestream to store the file bytes
                    FileStream fs = new FileStream(destination, FileMode.Create);
                    _file.CopyTo(fs);
                    fs.Close();
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Download(string id)
        {
            // 'id' is the filename

            string pathFile = Path.Combine(_he.ContentRootPath, "wwwroot/Documents/", id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(pathFile);

            string? mimeType;
            //this code assumes that content type is always obtained.
            //Otherwise, the result should be verified (boolean value)

            new FileExtensionContentTypeProvider().TryGetContentType(id, out mimeType);

            return File(fileBytes, mimeType);
        }

        //Homework
        public IActionResult Delete(string id)
        {

            string pathFile = Path.Combine(_he.ContentRootPath, "wwwroot/Documents/", id);
            System.IO.File.Delete(pathFile);

            return RedirectToAction(nameof(Index));
        }
        //Homework

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}