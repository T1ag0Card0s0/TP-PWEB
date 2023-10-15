using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HabitAqui.Data;
using HabitAqui.Models;
using Microsoft.CodeAnalysis;

namespace HabitAqui.Controllers
{
    public class HabitacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabitacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Habitacoes
        public async Task<IActionResult> Index(string category, string location, DateTime? start_date, DateTime? end_date, int? periodo, string locador)
        {
            var habitacoes = _context.Habitacao.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                if(category == "Apartamentos")
                {
                    habitacoes = habitacoes.Where(h => h.Categoria.Nome == "T1" || 
                    h.Categoria.Nome == "T2" || h.Categoria.Nome == "T3" || h.Categoria.Nome == "T4");
                }
                else {
                    habitacoes = habitacoes.Where(h => h.Categoria.Nome == category);
                }
                    
            }

            if (!string.IsNullOrEmpty(locador))
            {
                habitacoes = habitacoes.Where(h => h.Locador.Nome == locador);
            }

            if (!string.IsNullOrEmpty(location))
            {
                habitacoes = habitacoes.Where(h => h.Localizacao == location);
            }

            if (start_date.HasValue && end_date.HasValue)
            {
                habitacoes = habitacoes.Where(h =>
                    h.Data_inicio >= start_date.Value &&
                    h.Data_fim <= end_date.Value);
            }

            if (periodo.HasValue)
            {
                habitacoes = habitacoes.Where(h => h.PeriodoMinimo <= periodo.Value);
            }

            var resultado = habitacoes.ToList();

            return View(resultado);
        }

        // GET: Habitacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habitacao == null)
            {
                return NotFound();
            }

            var habitacao = await _context.Habitacao
                .Include(h => h.Categoria)
                .Include(h => h.Locador)
                .FirstOrDefaultAsync(m => m.HabitacaoId == id);
            if (habitacao == null)
            {
                return NotFound();
            }

            return View(habitacao);
        }

        // GET: Habitacoes/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nome");
            ViewData["LocadorId"] = new SelectList(_context.Locador, "LocadorId", "Nome");
            return View();
        }

        // POST: Habitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HabitacaoId,Descricao,Custo,CategoriaId,LocadorId")] Habitacao habitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nome", habitacao.CategoriaId);
            ViewData["LocadorId"] = new SelectList(_context.Locador, "LocadorId", "LocadorId", habitacao.LocadorId);
            return View(habitacao);
        }

        // GET: Habitacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habitacao == null)
            {
                return NotFound();
            }

            var habitacao = await _context.Habitacao.FindAsync(id);
            if (habitacao == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nome", habitacao.CategoriaId);
            ViewData["LocadorId"] = new SelectList(_context.Locador, "LocadorId", "LocadorId", habitacao.LocadorId);
            return View(habitacao);
        }

        // POST: Habitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabitacaoId,Descricao,Custo,CategoriaId,LocadorId")] Habitacao habitacao)
        {
            if (id != habitacao.HabitacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacaoExists(habitacao.HabitacaoId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nome", habitacao.CategoriaId);
            ViewData["LocadorId"] = new SelectList(_context.Locador, "LocadorId", "LocadorId", habitacao.LocadorId);
            return View(habitacao);
        }

        // GET: Habitacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habitacao == null)
            {
                return NotFound();
            }

            var habitacao = await _context.Habitacao
                .Include(h => h.Categoria)
                .Include(h => h.Locador)
                .FirstOrDefaultAsync(m => m.HabitacaoId == id);
            if (habitacao == null)
            {
                return NotFound();
            }

            return View(habitacao);
        }

        // POST: Habitacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habitacao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Habitacao'  is null.");
            }
            var habitacao = await _context.Habitacao.FindAsync(id);
            if (habitacao != null)
            {
                _context.Habitacao.Remove(habitacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacaoExists(int id)
        {
          return (_context.Habitacao?.Any(e => e.HabitacaoId == id)).GetValueOrDefault();
        }
    }
}
