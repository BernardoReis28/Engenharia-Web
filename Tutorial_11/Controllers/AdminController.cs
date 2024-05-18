using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tutorial_11.Data;
using Tutorial_11.Models;

namespace Tutorial_11.Controllers
{
    public class AdminController : Controller
    {
        private readonly Tutorial_11Context _context;

        public AdminController(Tutorial_11Context context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
              return _context.Person != null ? 
                          View(await _context.Person.ToListAsync()) :
                          Problem("Entity set 'Tutorial_11Context.Person'  is null.");
        }

        public IActionResult Create(string NewName)
        {
            Person newP = new Person();
            newP.Name = NewName;
            _context.Person.Add(newP);
            _context.SaveChanges();

            return PartialView("Listing", _context.Person);
        }

        public IActionResult Edit(int Id)
        {
            Person a = _context.Person.SingleOrDefault(x => x.Id == Id);
            return PartialView("Edit", a);
        }

        [HttpPost]
        public string Edit(int id, Person p)
        {
            _context.Update(p);
            _context.SaveChanges();
            return p.Name;
        }

        public IActionResult Delete(int id)
        {
            Person p = _context.Person.SingleOrDefault(x => x.Id == id);
            _context.Person.Remove(p);
            _context.SaveChanges();

            return PartialView("Listing", _context.Person);
        }
    }
}
