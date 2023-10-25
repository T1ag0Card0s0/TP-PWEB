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
    public class DanosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Danos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Danos.Include(d => d.Estado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Danos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Danos == null)
            {
                return NotFound();
            }

            var dano = await _context.Danos
                .Include(d => d.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dano == null)
            {
                return NotFound();
            }

            return View(dano);
        }

        // GET: Danos/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Id");
            return View();
        }

        // POST: Danos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Image,Fomat,EstadoId")] Dano dano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Id", dano.EstadoId);
            return View(dano);
        }

        // GET: Danos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Danos == null)
            {
                return NotFound();
            }

            var dano = await _context.Danos.FindAsync(id);
            if (dano == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Id", dano.EstadoId);
            return View(dano);
        }

        // POST: Danos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Image,Fomat,EstadoId")] Dano dano)
        {
            if (id != dano.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanoExists(dano.Id))
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
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Id", dano.EstadoId);
            return View(dano);
        }

        // GET: Danos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Danos == null)
            {
                return NotFound();
            }

            var dano = await _context.Danos
                .Include(d => d.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dano == null)
            {
                return NotFound();
            }

            return View(dano);
        }

        // POST: Danos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Danos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Danos'  is null.");
            }
            var dano = await _context.Danos.FindAsync(id);
            if (dano != null)
            {
                _context.Danos.Remove(dano);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanoExists(int id)
        {
          return (_context.Danos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
