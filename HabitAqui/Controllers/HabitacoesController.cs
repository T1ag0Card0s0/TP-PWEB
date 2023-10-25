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
                habitacoes = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).ToList();
            }
            // Retrieve the list of Categoria names from the database
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();

            // Pass the list of Categoria names to the view
            ViewData["CategoriaNames"] = categoriaNames;
            return View(habitacoes);
        }

        // metodo chamado para aplicar os filtros e retornar a nova lista para o Index
        [HttpPost]
        public IActionResult Filter(string[] SelectedCategories, string? locador)
        {
            // Retrieve the list of Categoria names from the database
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();

            // Pass the list of Categoria names to the view
            ViewData["CategoriaNames"] = categoriaNames;
            var habitacao = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).AsQueryable();


            if (locador != null)
            {
                habitacao = habitacao.Where(h => h.Locador.Nome.Contains(locador));
            }

            if (SelectedCategories != null && SelectedCategories.Length > 0)
            {
                habitacao = habitacao.Where(h => SelectedCategories.Contains(h.Categoria.Nome));
            }

            var resultado = habitacao.ToList();


            return View("Index", resultado);
        }
        // metodo chamado para ordenar os resultados e retornar a nova lista
        [HttpPost]
        public async Task<IActionResult> OrderSearch(string preco, string avaliacao)
        {
        
            var habitacao = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).Include(h => h.Avaliacoes).AsQueryable();

            if (preco != null)
            {
                if (preco == "crescente")
                    habitacao = habitacao.OrderBy(h => h.Custo);
                else
                    habitacao = habitacao.OrderByDescending(h => h.Custo);
            }
            if (avaliacao != null) {
                if (avaliacao == "crescente")
                    habitacao = habitacao.OrderBy(h => h.Locador.MediaAvaliacao);
                else
                    habitacao = habitacao.OrderByDescending(h => h.Locador.MediaAvaliacao);
            }
            // Retrieve the list of Categoria names from the database
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();

            // Pass the list of Categoria names to the view
            ViewData["CategoriaNames"] = categoriaNames;

            return View("Index", habitacao.ToList());
        }


        // GET: Habitacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habitacoes == null)
            {
                return NotFound();
            }

            var habitacao = await _context.Habitacoes
                .Include(h => h.Categoria)
                .Include(h => h.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habitacao == null)
            {
                return NotFound();
            }

            return View(habitacao);
        }

        // GET: Habitacoes/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId");
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "Id", "Id");
            return View();
        }

        // POST: Habitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeriodoMinimoArrendamento,PeriodoMaximoArrendamento,Custo,Ativo,Cidade,Rua,Numero,Andar,NumeroPorta,CategoriaId,LocadorId")] Habitacao habitacao)
        {
            if (ModelState.IsValid)
            {
                habitacao.MediaAvaliacao = 0;
                _context.Add(habitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", habitacao.CategoriaId);
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "Id", "Id", habitacao.LocadorId);
            return View(habitacao);
        }

        // GET: Habitacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habitacoes == null)
            {
                return NotFound();
            }

            var habitacao = await _context.Habitacoes.FindAsync(id);
            if (habitacao == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", habitacao.CategoriaId);
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "Id", "Id", habitacao.LocadorId);
            return View(habitacao);
        }

        // POST: Habitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PeriodoMinimoArrendamento,PeriodoMaximoArrendamento,Custo,MediaAvaliacao,Ativo,Cidade,Rua,Numero,Andar,NumeroPorta,CategoriaId,LocadorId")] Habitacao habitacao)
        {
            if (id != habitacao.Id)
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
                    if (!HabitacaoExists(habitacao.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", habitacao.CategoriaId);
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "Id", "Id", habitacao.LocadorId);
            return View(habitacao);
        }

        // GET: Habitacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habitacoes == null)
            {
                return NotFound();
            }

            var habitacao = await _context.Habitacoes
                .Include(h => h.Categoria)
                .Include(h => h.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.Habitacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Habitacoes'  is null.");
            }
            var habitacao = await _context.Habitacoes.FindAsync(id);
            if (habitacao != null)
            {
                _context.Habitacoes.Remove(habitacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacaoExists(int id)
        {
          return (_context.Habitacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
