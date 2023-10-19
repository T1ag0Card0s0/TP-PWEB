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

        // controller for initial search
        // GET: Habitacoes
        public async Task<IActionResult> Index(string category, string location, DateTime? start_date, DateTime? end_date, int? periodo)
        {
            //var habitacoes = _context.Habitacao.AsQueryable();
            var habitacoes = _context.Habitacao.Include(h => h.Categoria).Include(h => h.Locador).AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                if (category == "Apartamentos")
                {
                    habitacoes = habitacoes.Where(h => h.Categoria.Nome == "T1" ||
                    h.Categoria.Nome == "T2" || h.Categoria.Nome == "T3" || h.Categoria.Nome == "T4");
                }
                else
                {
                    habitacoes = habitacoes.Where(h => h.Categoria.Nome.Contains(category));
                }
            }

            if (!string.IsNullOrEmpty(location))
            {
                habitacoes = habitacoes.Where(h => h.Localizacao.Contains(location));
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

        // controller for filters search
        [HttpPost]
        public async Task<IActionResult> Search(string[] category, string locador)
        {
            var habitacao = _context.Habitacao.Include(h => h.Categoria).Include(h => h.Locador).AsQueryable();

            if (category != null && category.Length > 0)
            {
                foreach (string selectedCategory in category)
                {
                    habitacao = habitacao.Where(h => h.Categoria.Nome.Contains(selectedCategory));
                }
            }

            if (locador != null)
            {
                habitacao = habitacao.Where(h => h.Locador.Nome.Contains(locador));
            }

            return View(await habitacao.ToListAsync());
        }


        // controller for order search
        [HttpPost]
        public async Task<IActionResult> OrderSearch(string preco, string avaliacao)
        {
            var habitacao = _context.Habitacao.Include(h => h.Categoria).Include(h => h.Locador).Include(h=>h.Avaliacoes).AsQueryable();
           
            if (preco!= null)
            {
                if (preco == "crescente")
                    habitacao = habitacao.OrderBy(h => h.Custo);
                else
                    habitacao = habitacao.OrderByDescending(h => h.Custo);
            }
            return View(await habitacao.ToListAsync());
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
