using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turno2P1.Models;

namespace Turno2P1.Controllers
{
    public class EstanteController : Controller
    {
        private readonly DB_al73991 _context;
        private readonly IHostEnvironment _he;

        public EstanteController(DB_al73991 context, IHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        // GET: Estante
        public async Task<IActionResult> Index()
        {
              return _context.Jogo != null ? 
                          View(await _context.Jogo.ToListAsync()) :
                          Problem("Entity set 'DB_al73991.Jogo'  is null.");
        }

        // GET: Estante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jogo == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // GET: Estante/Create
        public IActionResult Introduzir()
        {
            return View();
        }

        // POST: Estante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Introduzir([Bind("Id,Nome,Descricao,Foto,Pontuacao,Estado")] Jogo jogo, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto != null)
                {
                    string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Fotos/", Path.GetFileName(Foto.FileName));
                    FileStream fs = new FileStream(destination, FileMode.Create);
                    Foto.CopyTo(fs);
                    fs.Close();

                    jogo.Foto = Foto.FileName;
                }

                _context.Add(jogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogo);
        }

        public async Task<IActionResult> Aumenta(int id)
        {
            var jogo = _context.Jogo.Single(x => x.Id == id);
            jogo.Pontuacao++;
            _context.Jogo.Update(jogo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Diminui(int id)
        {
            var jogo = _context.Jogo.Single(x => x.Id == id);
            jogo.Pontuacao--;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remover(int id)
        {
            var jogo = _context.Jogo.Single(x => x.Id == id);
            jogo.Estado = false;
            _context.Jogo.Update(jogo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        // GET: Estante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jogo == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogo.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }
            return View(jogo);
        }

        // POST: Estante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Foto,Pontuacao,Estado")] Jogo jogo)
        {
            if (id != jogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(jogo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jogo);
        }

        // GET: Estante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jogo == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // POST: Estante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jogo == null)
            {
                return Problem("Entity set 'DB_al73991.Jogo'  is null.");
            }
            var jogo = await _context.Jogo.FindAsync(id);
            if (jogo != null)
            {
                _context.Jogo.Remove(jogo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoExists(int id)
        {
          return (_context.Jogo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
