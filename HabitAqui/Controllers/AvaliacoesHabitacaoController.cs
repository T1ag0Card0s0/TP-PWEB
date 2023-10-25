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
    public class AvaliacoesHabitacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvaliacoesHabitacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AvaliacoesHabitacao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AvaliacoesHabitacao.Include(a => a.Cliente).Include(a => a.Habitacao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AvaliacoesHabitacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvaliacoesHabitacao == null)
            {
                return NotFound();
            }

            var avaliacaoHabitacao = await _context.AvaliacoesHabitacao
                .Include(a => a.Cliente)
                .Include(a => a.Habitacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaliacaoHabitacao == null)
            {
                return NotFound();
            }

            return View(avaliacaoHabitacao);
        }

        // GET: AvaliacoesHabitacao/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["HabitacaoId"] = new SelectList(_context.Habitacoes, "Id", "Id");
            return View();
        }

        // POST: AvaliacoesHabitacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Classificacao,Descricao,HabitacaoId,ClienteId")] AvaliacaoHabitacao avaliacaoHabitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacaoHabitacao);
                await _context.SaveChangesAsync();
                // After saving the new Avaliacao, calculate the updated MediaAvaliacao.
                UpdateLocadorMediaAvaliacao(avaliacaoHabitacao.HabitacaoId);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", avaliacaoHabitacao.ClienteId);
            ViewData["HabitacaoId"] = new SelectList(_context.Habitacoes, "Id", "Id", avaliacaoHabitacao.HabitacaoId);
            return View(avaliacaoHabitacao);
        }

        private void UpdateLocadorMediaAvaliacao(int? habitacaoId)
        {
            if (habitacaoId == null) return;
            // Fetch the Locador entity by its ID.
            var habitacao = _context.Habitacoes.Find(habitacaoId);

            if (habitacao != null)
            {
                // Calculate the new MediaAvaliacao based on all associated Avaliacoes.
                double newMediaAvaliacao = _context.AvaliacoesHabitacao
                    .Where(avaliacao => avaliacao.HabitacaoId == habitacaoId)
                    .Average(avaliacao => avaliacao.Classificacao);

                // Update the MediaAvaliacao property of the Locador.
                habitacao.MediaAvaliacao = newMediaAvaliacao;

                // Save the changes to the database.
                _context.SaveChanges();
            }
        }

        // GET: AvaliacoesHabitacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvaliacoesHabitacao == null)
            {
                return NotFound();
            }

            var avaliacaoHabitacao = await _context.AvaliacoesHabitacao.FindAsync(id);
            if (avaliacaoHabitacao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", avaliacaoHabitacao.ClienteId);
            ViewData["HabitacaoId"] = new SelectList(_context.Habitacoes, "Id", "Id", avaliacaoHabitacao.HabitacaoId);
            return View(avaliacaoHabitacao);
        }

        // POST: AvaliacoesHabitacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Classificacao,Descricao,HabitacaoId,ClienteId")] AvaliacaoHabitacao avaliacaoHabitacao)
        {
            if (id != avaliacaoHabitacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacaoHabitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoHabitacaoExists(avaliacaoHabitacao.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", avaliacaoHabitacao.ClienteId);
            ViewData["HabitacaoId"] = new SelectList(_context.Habitacoes, "Id", "Id", avaliacaoHabitacao.HabitacaoId);
            return View(avaliacaoHabitacao);
        }

        // GET: AvaliacoesHabitacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvaliacoesHabitacao == null)
            {
                return NotFound();
            }

            var avaliacaoHabitacao = await _context.AvaliacoesHabitacao
                .Include(a => a.Cliente)
                .Include(a => a.Habitacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaliacaoHabitacao == null)
            {
                return NotFound();
            }

            return View(avaliacaoHabitacao);
        }

        // POST: AvaliacoesHabitacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvaliacoesHabitacao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AvaliacoesHabitacao'  is null.");
            }
            var avaliacaoHabitacao = await _context.AvaliacoesHabitacao.FindAsync(id);
            if (avaliacaoHabitacao != null)
            {
                _context.AvaliacoesHabitacao.Remove(avaliacaoHabitacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoHabitacaoExists(int id)
        {
          return (_context.AvaliacoesHabitacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
