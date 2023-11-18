using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HabitAqui.Data;
using HabitAqui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HabitAqui.Controllers
{
    public class ArrendamentosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ArrendamentosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index(List<Arrendamento> arrendamentos)
        {
            var categoriaNames = _context.Categorias.ToList();
            ViewData["Categorias"] = categoriaNames;

            var clientesNames = _context.Clientes.ToList();
            ViewData["Clientes"] = clientesNames;
            if (arrendamentos == null || !arrendamentos.Any())
            {
                arrendamentos = _context.Arrendamentos
                    .Include(a => a.Cliente).
                    Include(a => a.FuncionarioEntrega)
                    .Include(a => a.Habitacao)
                    .Include(a => a.Habitacao.Categoria)
                    .Include(a => a.Locador).ToList();
            }

            return View(arrendamentos);
        }

        public IActionResult ListArrendamentos()
        {
            var arrendamentos = _context.Arrendamentos
                .Include(a => a.Cliente)
                .Include(a => a.FuncionarioEntrega)
                .Include(a => a.Habitacao)
                .Include(a => a.Habitacao.Categoria)
                .Include(a => a.Locador).AsQueryable();

            // substituir por funcao obterlocador id
            var user_atual = _userManager.GetUserAsync(User).Result;
            int id = -1;
            if (_userManager.IsInRoleAsync(user_atual, "Funcionario").Result)
            {
                var user = _context.Funcionarios.FirstOrDefault(f => f.ApplicationUser.Id == _userManager.GetUserId(User));
                id = user.LocadorId;
            }
            else if (_userManager.IsInRoleAsync(user_atual, "Gestor").Result)
            {
                var user = _context.Gestores.FirstOrDefault(f => f.ApplicationUser.Id == _userManager.GetUserId(User));
                id = user.LocadorId;
            }

            if (id != -1)
                arrendamentos = arrendamentos.Where(a => a.LocadorId == id);

            return View("Index", arrendamentos);

        }
        public IActionResult ListClienteArrendamentos()
        {
            var cliente = _userManager.GetUserAsync(User).Result;

            var arrendamentos = _context.Arrendamentos.Include(a => a.Cliente).
                Include(a => a.FuncionarioEntrega).Include(a => a.Habitacao).Include(a => a.Habitacao.Categoria).Include(a => a.Locador).AsQueryable();

            arrendamentos = arrendamentos.Where(a => a.Cliente.ApplicationUser.Id.Equals(cliente.Id));

            return View("Index", arrendamentos);
        }

        public IActionResult Filter(string categoria, string cliente, DateTime start_date, DateTime end_date, string order)
        {
            var categoriaNames = _context.Categorias.ToList();
            ViewData["Categorias"] = categoriaNames;

            var clientesNames = _context.Clientes.ToList();
            ViewData["Clientes"] = clientesNames;

            var locadorId = ObterLocadorIdAtual();

            var arrendamentosFiltrados = _context.Arrendamentos
                .Include(h => h.Habitacao)
                .Include(h => h.Habitacao.Categoria)
                .Include(h => h.Cliente)
                .Include(h => h.Locador)
                .Where(h => h.LocadorId == locadorId);

            if (!string.IsNullOrEmpty(categoria))
            {
                arrendamentosFiltrados = arrendamentosFiltrados.Where(h => h.Habitacao.Categoria.Nome.Contains(categoria));
            }

            if (start_date != default(DateTime))
            {
                arrendamentosFiltrados = arrendamentosFiltrados.Where(a => a.DataInicio >= start_date);
            }
            if (start_date != default(DateTime))
            {
                arrendamentosFiltrados = arrendamentosFiltrados.Where(a => a.DataFim <= end_date);
            }

            if (!string.IsNullOrEmpty(order))
            {
                if (order.Equals("PrecoCrescente"))
                {
                    arrendamentosFiltrados = arrendamentosFiltrados.OrderBy(h => h.Custo); // Ordenar o preço de forma crescente
                }
                else if (order.Equals("PrecoDecrescente"))
                {
                    arrendamentosFiltrados = arrendamentosFiltrados.OrderByDescending(h => h.Custo); // Ordenar o preço de forma decrescente

                }
                else if (order.Equals("AvalicaoCrescente"))
                {
                    arrendamentosFiltrados = arrendamentosFiltrados.OrderBy(h => h.Habitacao.MediaAvaliacao); // Ordenar a avaliação de forma crescente
                }
                else if (order.Equals("AvaliacaoDecrescente"))
                {
                    arrendamentosFiltrados = arrendamentosFiltrados.OrderByDescending(h => h.Habitacao.MediaAvaliacao); // Ordenar a avaliação de forma decrescente
                }
            }
            return View("Index", arrendamentosFiltrados);
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

        // GET: Arrendamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Arrendamentos == null)
            {
                return NotFound();
            }

            var arrendamento = await _context.Arrendamentos
                .Include(a => a.Cliente)
                .Include(a => a.FuncionarioEntrega)
                .Include(a => a.Habitacao)
                .Include(a => a.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arrendamento == null)
            {
                return NotFound();
            }

            return View(arrendamento);
        }

        // GET: Arrendamentos/Create
        public IActionResult Create(int id)
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome");
            ViewData["FuncionarioEntregaId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "Nome");
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "LocadorId", "Nome");
            ViewData["HabitacaoId"] = new SelectList(_context.Habitacoes, "Id", "Id");
           
            return View();
        }

        // POST: Arrendamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataInicio,DataFim,Custo,ClienteId,HabitacaoId,Observacoes,FuncionarioEntregaId,LocadorId,DataEntrega")] Arrendamento arrendamento)
        {
            _context.Add(arrendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }

        // GET: Arrendamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Arrendamentos == null)
            {
                return NotFound();
            }

            var arrendamento = await _context.Arrendamentos.FindAsync(id);
            if (arrendamento == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", arrendamento.ClienteId);
            ViewData["FuncionarioEntregaId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "FuncionarioId", arrendamento.FuncionarioEntregaId);
            ViewData["HabitacaoId"] = new SelectList(_context.Habitacoes, "Id", "Id", arrendamento.HabitacaoId);
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "LocadorId", "LocadorId", arrendamento.LocadorId);
            return View(arrendamento);
        }

        // POST: Arrendamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataInicio,DataFim,Custo,ClienteId,HabitacaoId,Observacoes,FuncionarioEntregaId,LocadorId,DataEntrega")] Arrendamento arrendamento)
        {
            if (id != arrendamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArrendamentoExists(arrendamento.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", arrendamento.ClienteId);
            ViewData["FuncionarioEntregaId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "FuncionarioId", arrendamento.FuncionarioEntregaId);
            ViewData["HabitacaoId"] = new SelectList(_context.Habitacoes, "Id", "Id", arrendamento.HabitacaoId);
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "LocadorId", "LocadorId", arrendamento.LocadorId);
            return View(arrendamento);
        }

        // GET: Arrendamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Arrendamentos == null)
            {
                return NotFound();
            }

            var arrendamento = await _context.Arrendamentos
                .Include(a => a.Cliente)
                .Include(a => a.FuncionarioEntrega)
                .Include(a => a.Habitacao)
                .Include(a => a.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arrendamento == null)
            {
                return NotFound();
            }

            return View(arrendamento);
        }

        // POST: Arrendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Arrendamentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Arrendamentos'  is null.");
            }
            var arrendamento = await _context.Arrendamentos.FindAsync(id);
            if (arrendamento != null)
            {
                _context.Arrendamentos.Remove(arrendamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArrendamentoExists(int id)
        {
          return (_context.Arrendamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
