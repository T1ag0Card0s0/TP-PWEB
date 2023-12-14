using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HabitAqui.Data;
using HabitAqui.Models;

namespace HabitAqui.Controllers
{
    public class LocadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locadores
        public async Task<IActionResult> Index()
        {
              return _context.Locadores != null ? 
                          View(await _context.Locadores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Locadores'  is null.");
        }

        // GET: Locadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locadores == null)
            {
                return NotFound();
            }

            var locador = await _context.Locadores
                .FirstOrDefaultAsync(m => m.LocadorId == id);
            if (locador == null)
            {
                return NotFound();
            }

            return View(locador);
        }

        // GET: Locadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocadorId,Nome,Email,EstadoDeSubscricao,MediaAvaliacao")] Locador locador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locador);
        }

        // GET: Locadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locadores == null)
            {
                return NotFound();
            }

            var locador = await _context.Locadores.FindAsync(id);
            if (locador == null)
            {
                return NotFound();
            }

            return View(locador);
        }


        // POST: Locadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocadorId,Nome,EstadoDeSubscricao,MediaAvaliacao")] Locador locador)
        {
            if (id != locador.LocadorId)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(locador.Habitacoes));
            ModelState.Remove(nameof(locador.Arrendamentos));
            ModelState.Remove(nameof(locador.Avaliacoes));
            ModelState.Remove(nameof(locador.Funcionarios));
            ModelState.Remove(nameof(locador.Gestores));
            ModelState.Remove(nameof(locador.Email));


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocadorExists(locador.LocadorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ListLocadores", "Administradores");
            }
            return View(locador);
        }

        // GET: Locadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locadores == null)
            {
                return NotFound();
            }

            var locador = await _context.Locadores
                .FirstOrDefaultAsync(m => m.LocadorId == id);
            if (locador == null)
            {
                return NotFound();
            }

            if (_context.Habitacoes.Any(h => h.LocadorId == id))
            {
                return RedirectToAction("ListLocadores", "Administradores");
            }

            return View(locador);
        }

        // POST: Locadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locadores = _context.Locadores.ToList();
            if (locadores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Locadores'  is null.");
            }
            var locador = locadores.Where(c=> c.LocadorId == id).FirstOrDefault();
            if (locador != null)
            {
                _context.Locadores.Remove(locador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ListLocadores", "Administradores");
        }

        private bool LocadorExists(int id)
        {
          return (_context.Locadores?.Any(e => e.LocadorId == id)).GetValueOrDefault();
        }
    }
}
