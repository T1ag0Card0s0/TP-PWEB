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
    public class AvaliacaoesLocadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoesLocadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AvaliacaoesLocador
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AvaliacoesLocador.Include(a => a.Cliente).Include(a => a.Locador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AvaliacaoesLocador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvaliacoesLocador == null)
            {
                return NotFound();
            }

            var avaliacaoLocador = await _context.AvaliacoesLocador
                .Include(a => a.Cliente)
                .Include(a => a.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaliacaoLocador == null)
            {
                return NotFound();
            }

            return View(avaliacaoLocador);
        }

        // GET: AvaliacaoesLocador/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "Id", "Id");
            return View();
        }

        // POST: AvaliacaoesLocador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Classificacao,Descricao,LocadorId,ClienteId")] AvaliacaoLocador avaliacaoLocador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacaoLocador);
                await _context.SaveChangesAsync();

                // After saving the new Avaliacao, calculate the updated MediaAvaliacao.
                UpdateLocadorMediaAvaliacao(avaliacaoLocador.LocadorId);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", avaliacaoLocador.ClienteId);
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "Id", "Id", avaliacaoLocador.LocadorId);
            return View(avaliacaoLocador);
        }

        private void UpdateLocadorMediaAvaliacao(int? locadorId)
        {
            if (locadorId == null) return;
            // Fetch the Locador entity by its ID.
            var locador = _context.Locadores.Find(locadorId);

            if (locador != null)
            {
                // Calculate the new MediaAvaliacao based on all associated Avaliacoes.
                double newMediaAvaliacao = _context.AvaliacoesLocador
                    .Where(avaliacao => avaliacao.LocadorId == locadorId)
                    .Average(avaliacao => avaliacao.Classificacao);

                // Update the MediaAvaliacao property of the Locador.
                locador.MediaAvaliacao = newMediaAvaliacao;

                // Save the changes to the database.
                _context.SaveChanges();
            }
        }


        // GET: AvaliacaoesLocador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvaliacoesLocador == null)
            {
                return NotFound();
            }

            var avaliacaoLocador = await _context.AvaliacoesLocador.FindAsync(id);
            if (avaliacaoLocador == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", avaliacaoLocador.ClienteId);
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "Id", "Id", avaliacaoLocador.LocadorId);
            return View(avaliacaoLocador);
        }

        // POST: AvaliacaoesLocador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Classificacao,Descricao,LocadorId,ClienteId")] AvaliacaoLocador avaliacaoLocador)
        {
            if (id != avaliacaoLocador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacaoLocador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoLocadorExists(avaliacaoLocador.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", avaliacaoLocador.ClienteId);
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "Id", "Id", avaliacaoLocador.LocadorId);
            return View(avaliacaoLocador);
        }

        // GET: AvaliacaoesLocador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvaliacoesLocador == null)
            {
                return NotFound();
            }

            var avaliacaoLocador = await _context.AvaliacoesLocador
                .Include(a => a.Cliente)
                .Include(a => a.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaliacaoLocador == null)
            {
                return NotFound();
            }

            return View(avaliacaoLocador);
        }

        // POST: AvaliacaoesLocador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvaliacoesLocador == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AvaliacoesLocador'  is null.");
            }
            var avaliacaoLocador = await _context.AvaliacoesLocador.FindAsync(id);
            if (avaliacaoLocador != null)
            {
                _context.AvaliacoesLocador.Remove(avaliacaoLocador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoLocadorExists(int id)
        {
          return (_context.AvaliacoesLocador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
