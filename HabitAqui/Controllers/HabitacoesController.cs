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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using HabitAqui.ViewModels;
using SQLitePCL;

namespace HabitAqui.Controllers
{
    
    [Authorize(Roles = "Admin,Cliente,Gestor, Funcionario")]
    public class HabitacoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HabitacoesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin,Cliente,Gestor, Funcionario")]
        // GET: Habitacoes
        public IActionResult Index(List<Habitacao> habitacoes)
        {
            var categoriaNames = _context.Categorias.ToList();
            ViewData["Categorias"] = categoriaNames;
            // Se habitacoes for nulo (ou seja, nenhum resultado de pesquisa), carrega todas as habitacoes
            if (habitacoes == null || !habitacoes.Any())
            {
                habitacoes = _context.Habitacoes.Include(h => h.Categoria)
                    .Include(h => h.Locador)
                    .ToList();
            }
            
            return View(habitacoes);
        }

        [Authorize(Roles = "Gestor, Funcionario")]
        public IActionResult Listar()
        {
            var categoriaNames = _context.Categorias.ToList();
            ViewData["Categorias"] = categoriaNames;

            var locadorId = ObterLocadorIdAtual();
            var habitacoes = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador)
                    .Where(h => h.LocadorId == locadorId).ToList();

            return View("Index", habitacoes);
        }

        public IActionResult Filter(string categoria, string estado, string minPrice, string maxPrice, string order)
        {
            var categoriaNames = _context.Categorias.ToList();
            ViewData["Categorias"] = categoriaNames;

            var locadorId = ObterLocadorIdAtual(); 

            var habitacoesFiltradas = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador)
                .Where(h => h.LocadorId == locadorId);

            if (!string.IsNullOrEmpty(categoria))
            {
                habitacoesFiltradas = habitacoesFiltradas.Where(h => h.Categoria.Nome.Contains(categoria));
            }

            if(string.Equals(estado, "ativo"))
                habitacoesFiltradas = habitacoesFiltradas.Where(h => h.Ativo == true);

            if (string.Equals(estado, "nao_ativo"))
                habitacoesFiltradas = habitacoesFiltradas.Where(h => h.Ativo == false);

            if (!string.IsNullOrEmpty(minPrice))
                habitacoesFiltradas = habitacoesFiltradas.Where(h => h.Custo >= int.Parse(minPrice));
    
            if(maxPrice != null)
                habitacoesFiltradas = habitacoesFiltradas.Where(h => h.Custo <= int.Parse(maxPrice));

            if (!string.IsNullOrEmpty(order)) { 
                if (order.Equals("PrecoCrescente"))
                {
                    habitacoesFiltradas = habitacoesFiltradas.OrderBy(h => h.Custo); // Ordenar o preço de forma crescente
                }
                else if (order.Equals("PrecoDecrescente"))
                {
                    habitacoesFiltradas = habitacoesFiltradas.OrderByDescending(h => h.Custo); // Ordenar o preço de forma decrescente

                }
                else if (order.Equals("AvalicaoCrescente"))
                {
                    habitacoesFiltradas = habitacoesFiltradas.OrderBy(h => h.MediaAvaliacao); // Ordenar a avaliação de forma crescente
                }
                else if (order.Equals("AvaliacaoDecrescente"))
                {
                    habitacoesFiltradas = habitacoesFiltradas.OrderByDescending(h => h.MediaAvaliacao); // Ordenar a avaliação de forma decrescente
                }
            }
            return View("Index",habitacoesFiltradas.ToList());
        }

        private int ObterLocadorIdAtual()
        {
            var user_atual = _userManager.GetUserAsync(User).Result;
            if (_userManager.IsInRoleAsync(user_atual, "Funcionario").Result)
            {
                var user = _context.Funcionarios.FirstOrDefault(f => f.ApplicationUser.Id == _userManager.GetUserId(User));
                return (user.LocadorId);
            }
            else if (_userManager.IsInRoleAsync(user_atual, "Gestor").Result)
            {
                var user = _context.Gestores.FirstOrDefault(f => f.ApplicationUser.Id == _userManager.GetUserId(User));
                return (user.LocadorId);
            }

            return -1;
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

        [Authorize(Roles = "Cliente")]
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

            TempData["HabitacaoId"] = id;

            return View();
        }

        // POST: Habitacoes/Avaliar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Avaliar(int id, [Bind("Classificacao,Descricao,HabitacaoId")] AvaliacaoHabitacao avaliacao)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Recupere o valor da TempData
                    if (TempData.TryGetValue("HabitacaoId", out var habitacaoId))
                    {
                        avaliacao.HabitacaoId = (int)habitacaoId;
                    }

                    _context.Add(avaliacao);

                    var habitacao = _context.Habitacoes.Find(avaliacao.HabitacaoId);

                    // Atualizar a média de avaliação na Habitacao
                    if (habitacao != null)
                    {
                        habitacao.Avaliacoes.Add(avaliacao);

                        var avaliacoes = _context.AvaliacoesHabitacao.Where(a => a.HabitacaoId == habitacao.Id).ToList();

                        if (avaliacoes.Any())
                        {
                            habitacao.MediaAvaliacao = avaliacoes.Average(a => a.Classificacao);
                        }
                        
                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction("ListClienteArrendamentos", "Arrendamentos");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar a avaliação.");
                }
            }

            return View(avaliacao);
        }

        // GET: Habitacoes/Create
        [Authorize(Roles = "Gestor, Funcionario")]
        public IActionResult Create()
        {
            List<Categoria> listaCategorias = _context.Categorias.Where(c => c.Ativo == true).ToList();

            ViewData["Categorias"] = listaCategorias;
            return View();
        }


        // POST: Habitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Gestor, Funcionario")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeriodoMinimoArrendamento,PeriodoMaximoArrendamento,Custo,Ativo,Localizacao,CategoriaId")] Habitacao habitacao)
        {
            List<Categoria> listaCategorias = _context.Categorias.Where(c => c.Ativo == true).ToList();

            ViewData["Categorias"] = listaCategorias;

           
            ModelState.Remove(nameof(habitacao.Avaliacoes));
            ModelState.Remove(nameof(habitacao.Arrendamentos));
            ModelState.Remove(nameof(habitacao.Categoria));
            ModelState.Remove(nameof(habitacao.Locador));
            if (habitacao.PeriodoMinimoArrendamento > habitacao.PeriodoMaximoArrendamento)
            {
                ModelState.AddModelError("PeriodoMinimoArrendamento", "O periodo minimo não pode ser superior ao periodo máximo.");
                return View(habitacao);
            }
            if (ModelState.IsValid)
            {
                var categoriaNames = _context.Categorias.ToList();
                ViewData["Categorias"] = categoriaNames;


                habitacao.MediaAvaliacao = 0;
                habitacao.LocadorId = ObterLocadorIdAtual();
          
                _context.Add(habitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            
            return View(habitacao);
        }

        // GET: Habitacoes/Edit/5
        [Authorize(Roles = "Gestor, Funcionario")]
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
            ViewData["Categorias"] = new SelectList(_context.Categorias, "CategoriaId", "Nome");
            return View(habitacao);
        }

        // POST: Habitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Gestor, Funcionario")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PeriodoMinimoArrendamento,PeriodoMaximoArrendamento,Custo,MediaAvaliacao,Ativo,Localizacao,CategoriaId")] Habitacao habitacao)
        {
            if (id != habitacao.Id)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(habitacao.Avaliacoes));
            ModelState.Remove(nameof(habitacao.Arrendamentos));
            ModelState.Remove(nameof(habitacao.Categoria));
            ModelState.Remove(nameof(habitacao.Locador));

            if(ModelState.IsValid)
            {
                try
                {
                    habitacao.LocadorId = ObterLocadorIdAtual();
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
            return View(habitacao);
            
        }

        // GET: Habitacoes/Delete/5
        [Authorize(Roles = "Gestor, Funcionario")]
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
        [Authorize(Roles = "Gestor, Funcionario")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habitacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Habitacoes'  is null.");
            }
            
            var habitacao = await _context.Habitacoes.FindAsync(id);

            var arrenadamentos = _context.Arrendamentos
                .Where(a => a.HabitacaoId == habitacao.Id 
                && a.Estado != Estados.RECEBIDO
                && a.Estado != Estados.REJEITADO)
                .ToList();

            if (habitacao != null && !arrenadamentos.Any())
            {
                var avaliacoesRelacionadas = _context.AvaliacoesHabitacao.Where(a => a.HabitacaoId == id);
                if(avaliacoesRelacionadas != null)
                    _context.AvaliacoesHabitacao.RemoveRange(avaliacoesRelacionadas);
                _context.Habitacoes.Remove(habitacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool HabitacaoExists(int id)
        {
          return (_context.Habitacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
