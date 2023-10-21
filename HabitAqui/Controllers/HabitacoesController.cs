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
using System.Diagnostics;

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
        public IActionResult Index(List<Habitacao> habitacoes)
        {
            // Se habitacoes for nulo (ou seja, nenhum resultado de pesquisa), carrega todas as habitacoes
            if (habitacoes == null || !habitacoes.Any())
            {
                habitacoes = _context.Habitacao.Include(h => h.Categoria).Include(h => h.Locador).ToList();
            }

            return View(habitacoes);
        }

        // metodo chamado na view Home para fazer a pesquisa inicial
        [HttpPost]
        public IActionResult InitialSearch(string category, string location, DateTime? start_date, DateTime? end_date, int? periodo)
        {
            //var habitacoes = _context.Habitacao.AsQueryable();
            var habitacoes = _context.Habitacao.Include(h => h.Categoria).Include(h => h.Locador).AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                string[] types = { "T0", "T1", "T2", "T3", "T4", "T5"};

                if (category == "Apartamentos")
                {
                    habitacoes = habitacoes.Where(h => types.Contains(h.Categoria.Nome));
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

            return View("Index", resultado);
        }

        // cria lista de categorias existentes para mostrar nos filtros e muda para a view FilterSearch
        public IActionResult FilterSearch()
        {
            ViewBag.Categorias = _context.Categoria.ToList();
            return View("FilterSearch");
        }

        // metodo chamado para aplicar os filtros e retornar a nova lista para o Index
        [HttpPost]
        public IActionResult Filter(string[] SelectedCategories, string locador)
        {
            var habitacao = _context.Habitacao.Include(h => h.Categoria).Include(h => h.Locador).AsQueryable();
            
            if (SelectedCategories != null)
                habitacao = habitacao.Where(h => SelectedCategories.Contains(h.Categoria.Nome));

            if (!string.IsNullOrEmpty(locador))
                habitacao = habitacao.Where(h => h.Locador.Nome.Contains(locador));


            var resultado = habitacao.ToList();


            return View("Index", resultado);
        }


        // metodo chamado para ordenar os resultados e retornar a nova lista
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

            // FALTA AQUI ORDERNAR PELA AVALIACAO

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
