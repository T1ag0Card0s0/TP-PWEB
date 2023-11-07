using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HabitAqui.Data;
using HabitAqui.Models;
using Microsoft.AspNetCore.Authorization;

namespace HabitAqui.Controllers
{
    
    [Authorize(Roles = "Admin,Cliente,Gestor, Funcionario")]
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
            
            return View(habitacoes);
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

        // GET: Habitacoes/Avaliar/5
        public IActionResult Avaliar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacao = _context.Habitacoes
                .Include(h => h.Categoria)
                .Include(h => h.Locador)
                .FirstOrDefault(m => m.Id == id);

            if (habitacao == null)
            {
                return NotFound();
            }

            var avaliacao = new AvaliacaoHabitacao
            {
                HabitacaoId = id.Value
            };

            return View(avaliacao);
        }

        // POST: Habitacoes/Avaliar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Avaliar(int id, [Bind("Classificacao,Descricao,HabitacaoId")] AvaliacaoHabitacao avaliacao)
        {
            if (id != avaliacao.HabitacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Associar a avaliação à Habitacao
                    avaliacao.Habitacao = _context.Habitacoes.Find(avaliacao.HabitacaoId);

                    avaliacao.Id = 0;

                    _context.Add(avaliacao);
                    await _context.SaveChangesAsync();

                    // Atualizar a média de avaliação na Habitacao
                    var habitacao = _context.Habitacoes.Find(avaliacao.HabitacaoId);
                    if (habitacao != null)
                    {
                        var avaliacoes = _context.AvaliacoesHabitacao.Where(a => a.HabitacaoId == habitacao.Id).ToList();
                        if (avaliacoes.Any())
                        {
                            habitacao.MediaAvaliacao = avaliacoes.Average(a => a.Classificacao);
                        }
                        else
                        {
                            habitacao.MediaAvaliacao = 0;
                        }

                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction("Details", new { id = id });
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar a avaliação.");
                }
            }

            return View(avaliacao);
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
