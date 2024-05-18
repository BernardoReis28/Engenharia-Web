using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorial_06.Data;

namespace Tutorial_06.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Class06Context _context;
        public StudentsController(Class06Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allStudents = _context.Students.Include(c => c.Class);
            return View(allStudents);
        }

        public async Task<IActionResult> Index2(string letter)
        {
            ViewBag.letter = letter;

            if (!string.IsNullOrEmpty(letter))
            {
                return View(await _context.Students.Where(x => x.Name.StartsWith(letter)).Include(c => c.Class).ToListAsync());
            }
            else
                return View(await _context.Students.Include(c => c.Class).ToListAsync());
        }
        public async Task<IActionResult> Index3(string by, string way)
        {
            ViewBag.Order = by; // to draw the menus
            ViewBag.Way = way ?? ""; // to draw the menus

            var _list = await _context.Students.Include(c => c.Class).ToListAsync();

            switch (by)
            {
                case "byNumber":
                    if (way == "descending")
                        _list = await _context.Students.OrderByDescending(x => x.Number).Include(c => c.Class).ToListAsync();
                    else
                        _list = await _context.Students.OrderBy(x => x.Number).Include(c => c.Class).ToListAsync();
                    break;
                case "byName":
                    if (way == "descending")
                        _list = await _context.Students.OrderByDescending(x => x.Name).Include(c => c.Class).ToListAsync();
                    else
                        _list = await _context.Students.OrderBy(x => x.Name).Include(c => c.Class).ToListAsync();
                    break;
            }

            return View(_list);
        }
    }
}