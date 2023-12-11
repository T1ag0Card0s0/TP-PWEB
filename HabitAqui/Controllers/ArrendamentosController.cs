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
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using HabitAqui.ViewModels;
using System.IO;
using System.Collections;

namespace HabitAqui.Controllers
{
    public class ArrendamentosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ArrendamentosController> _logger;


        public ArrendamentosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<ArrendamentosController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
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
                    .Include(a => a.Cliente)
                    .Include(a => a.Habitacao)
                    .Include(a => a.Habitacao.Categoria)
                    .Include(a => a.Locador).ToList();
            }

            return View(arrendamentos);
        }

        public IActionResult ListArrendamentos()
        {
            var categoriaNames = _context.Categorias.ToList();
            ViewData["Categorias"] = categoriaNames;

            var clientesNames = _context.Clientes.ToList();
            ViewData["Clientes"] = clientesNames;
            var arrendamentos = _context.Arrendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Habitacao)
                .Include(a => a.Habitacao.Categoria)
                .Include(a => a.Locador).AsQueryable();

            int id = ObterLocadorIdAtual();

            if (id != -1)
                arrendamentos = arrendamentos.Where(a => a.LocadorId == id);

            return View("Index", arrendamentos);

        }
        public IActionResult ListClienteArrendamentos()
        {
            var categoriaNames = _context.Categorias.ToList();
            ViewData["Categorias"] = categoriaNames;

            var clientesNames = _context.Clientes.ToList();
            ViewData["Clientes"] = clientesNames;

            var cliente = _userManager.GetUserAsync(User).Result;

            var arrendamentos = _context.Arrendamentos.Include(a => a.Cliente)
                .Include(a => a.Habitacao).Include(a => a.Habitacao.Categoria).Include(a => a.Locador).AsQueryable();

            arrendamentos = arrendamentos.Where(a => a.Cliente.ApplicationUser.Id.Equals(cliente.Id));

            return View("Index", arrendamentos);
        }

        public IActionResult Filter(string categoria, string cliente, DateTime start_date, DateTime end_date, string order, string estado)
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

            if (!string.IsNullOrEmpty(cliente))
            {
                arrendamentosFiltrados = arrendamentosFiltrados.Where(h => h.Cliente.Nome.Contains(cliente));
            }

            if (estado == "CONFIRMADO")
                arrendamentosFiltrados = arrendamentosFiltrados.Where(h => h.Estado == Estados.CONFIRMADO || h.Estado ==Estados.ENTREGUE);
            else if (estado == "NAO_CONFIRMADO")
                arrendamentosFiltrados = arrendamentosFiltrados.Where(h => h.Estado == Estados.NAO_CONFIRMADO);
            else if (estado == "RECEBIDO")
                arrendamentosFiltrados = arrendamentosFiltrados.Where(h => h.Estado == Estados.RECEBIDO);

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

        [HttpGet]
        public IActionResult Cancelar(int id)
        {
            return AlterarEstadoArrendamento(id, Estados.REJEITADO);
        }

        [HttpGet]
        public IActionResult Confirmar(int id)
        {
            return AlterarEstadoArrendamento(id, Estados.CONFIRMADO);
        }

        public IActionResult AlterarEstadoArrendamento(int id, Estados estado)
        {
            var arrendamento = _context.Arrendamentos.Find(id);

            if (arrendamento == null)
            {
                return NotFound();
            }

            arrendamento.Estado = estado;
            _context.SaveChanges();

            return RedirectToAction("Index");
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
                .Include(a => a.EntregarArrendamento)
                .Include(a => a.EntregarArrendamento.FuncionarioEntrega)
                .Include(a => a.EntregarArrendamento.Equipamentos)
                .Include(a => a.Habitacao)
                .Include(a => a.Habitacao.Categoria)
                .Include(a => a.Locador)
                .Include(a => a.ReceberArrendamento)
                .Include(a => a.ReceberArrendamento.Equipamentos)
                .Include(a => a.ReceberArrendamento.FuncionarioRecebeu)
                .Include(a => a.Imagens)
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
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "LocadorId", "Nome");
            TempData["HabitacaoId"] = id;
            return View();
        }

        // POST: Arrendamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataInicio,DataFim,Custo,ClienteId,HabitacaoId,LocadorId")] Arrendamento arrendamento)
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome");

            ModelState.Remove(nameof(arrendamento.EntregarArrendamento));
            ModelState.Remove(nameof(arrendamento.Estado));
            ModelState.Remove(nameof(arrendamento.Imagens));
            ModelState.Remove(nameof(arrendamento.Habitacao));
            ModelState.Remove(nameof(arrendamento.Locador));
            ModelState.Remove(nameof(arrendamento.Cliente));
            ModelState.Remove(nameof(arrendamento.ReceberArrendamento));

            if (ModelState.IsValid)
            {
                // Recupere o valor da TempData
                if (TempData.TryGetValue("HabitacaoId", out var habitacaoId))
                {
                    arrendamento.HabitacaoId = (int)habitacaoId;
                }
                arrendamento.LocadorId = ObterLocadorIdAtual();
                arrendamento.Estado = Estados.NAO_CONFIRMADO;
                _context.Add(arrendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(arrendamento);
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

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome");
            ViewData["FuncionarioEntregaId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "Nome");
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "LocadorId", "Nome");
            var equipamentos = _context.Equipamentos.ToList();
            ViewData["Equipamentos"] = equipamentos;
            TempData["HabitacaoId"] = id;
            return View(arrendamento);
        }

        // POST: Arrendamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataInicio,DataFim,Custo,ClienteId,HabitacaoId,Observacoes,FuncionarioEntregaId,LocadorId,DataEntrega")] Arrendamento arrendamento, List<int> EquipamentosOpcionais)
        {
            if (id != arrendamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //arrendamento.EquipamentosOpcionais = new List<Equipamento>();

                    foreach (var equipamentoId in EquipamentosOpcionais)
                    {
                        var equipamento = await _context.Equipamentos.FindAsync(equipamentoId);

                        if (equipamento != null)
                        {
                            //arrendamento.EquipamentosOpcionais.Add(equipamento);
                        }
                    }
                    // Recupere o valor da TempData
                    if (TempData.TryGetValue("HabitacaoId", out var habitacaoId))
                    {
                        arrendamento.HabitacaoId = (int)habitacaoId;
                    }
                    arrendamento.LocadorId = ObterLocadorIdAtual();
                    _context.Add(arrendamento);
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
            ViewData["HabitacaoId"] = new SelectList(_context.Habitacoes, "Id", "Id", arrendamento.HabitacaoId);
            ViewData["LocadorId"] = new SelectList(_context.Locadores, "LocadorId", "LocadorId", arrendamento.LocadorId);
            var equipamentos = _context.Equipamentos.ToList();
            ViewData["Equipamentos"] = equipamentos;
            return RedirectToAction(nameof(Index));
        }
        // GET: Arrendamentos/Entregar/5
        public async Task<IActionResult> Entregar(int? id)
        {
            if (id == null || _context.Arrendamentos == null)
            {
                return NotFound();
            }

            var arrendamento = await _context.Arrendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Habitacao)
                .Include(a => a.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (arrendamento == null)
            {
                return NotFound();
            }

            var equipamentos = _context.Equipamentos.ToList();
            ViewData["Equipamentos"] = equipamentos;

            var funcionarios = _context.Funcionarios.ToList();
            ViewData["Funcionarios"] = funcionarios;

            var viewModel = new EntregaHabitacaoViewModel();

            return View(viewModel);
        }

        // POST: Arrendamentos/Entregar/5
        [HttpPost, ActionName("Entregar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EntregarConfirmed(int id, EntregaHabitacaoViewModel viewModel, List<int> ids)
        {
            
            var arrendamento = await _context.Arrendamentos.FindAsync(id);

            if (arrendamento != null)
            {
                arrendamento.Estado = Estados.ENTREGUE;
                List<Equipamento> equipamentos = null;
                if (ids.Any() || ids != null)
                    equipamentos = _context.Equipamentos.Where(e => ids.Contains(e.Id)).ToList();
                EntregarArrendamento entregaArrendamento = new EntregarArrendamento
                {
                    Observacoes = viewModel.Observacoes,
                    Danos = viewModel.Danos,
                    FuncionarioEntregaId = viewModel.FuncionarioEntregaId,
                    DataEntrega = DateTime.Now,
                    Equipamentos = equipamentos ?? new List<Equipamento>()
                };

                arrendamento.EntregarArrendamento = entregaArrendamento;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Arrendamentos/Receber/5
        public async Task<IActionResult> Receber(int? id)
        {
            if (id == null || _context.Arrendamentos == null)
            {
                return NotFound();
            }

            var arrendamento = await _context.Arrendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Habitacao)
                .Include(a => a.Locador)
                .Include(a => a.EntregarArrendamento)
                .Include(a => a.EntregarArrendamento.Equipamentos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (arrendamento == null)
            {
                return NotFound();
            }

            var equipamentos = arrendamento.EntregarArrendamento.Equipamentos.ToList();
            ViewData["Equipamentos"] = equipamentos;

            var funcionarios = _context.Funcionarios.ToList();
            ViewData["Funcionarios"] = funcionarios;

            var viewModel = new RecebeHabitacaoViewModel();
            return View(viewModel);
        }
        // POST: Arrendamentos/Receber/5
        [HttpPost, ActionName("Receber")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReceberConfirmed(int id, RecebeHabitacaoViewModel viewModel)
        {
            var arrendamento = await _context.Arrendamentos.FindAsync(id);

            if (arrendamento != null)
            {
                // insere as fotos numa diretoria do tipo wwroot/img/arrendamentos_danos/id
                if (viewModel.danosFotos != null && viewModel.danosFotos.Any())
                {
                    var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "arrendamentos_danos", arrendamento.Id.ToString());

                    if (!Directory.Exists(caminhoPasta))
                    {
                        Directory.CreateDirectory(caminhoPasta);
                    }
                    
                    foreach (var file in viewModel.danosFotos)
                    {
                        var targetFilePath = Path.Combine(caminhoPasta, file.FileName);
                        using (var stream = new FileStream(targetFilePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        var filePath = Path.Combine("img", "arrendamentos_danos", arrendamento.Id.ToString(), file.FileName);
                        filePath = filePath.Replace('\\', '/');
                        Imagem img = new Imagem()
                        {
                            Path = filePath
                        };
                        arrendamento.Imagens.Add(img);
                    }
                    
                }

                if(viewModel.EquipamentoEstado != null)
                {
                    foreach (var equipamentoEstado in viewModel.EquipamentoEstado)
                    {
                        int equipamentoId = equipamentoEstado.Key;
                        string estado = equipamentoEstado.Value;

                        var equipamento = _context.Equipamentos.Where(e => e.Id == equipamentoId).FirstOrDefault();
                        if (equipamento != null)
                        {
                            if (estado.Equals("BOM"))
                                equipamento.EquipamentoEstado = EquipamentoEstado.BOM;
                            else if (estado.Equals("DANIFICADO"))
                                equipamento.EquipamentoEstado = EquipamentoEstado.DANIFICADO;
                            else if (estado.Equals("EM_FALTA"))
                                equipamento.EquipamentoEstado = EquipamentoEstado.EM_FALTA;
                        }
                    }
                }
               
                ReceberArrendamento receberArrendamento = new ReceberArrendamento
                {
                    Danos = viewModel.Danos,
                    FuncionarioRecebeuId = viewModel.FuncionarioRecebeuId,
                    Observacoes = viewModel.Observacoes
                };
                arrendamento.Estado = Estados.RECEBIDO;
                arrendamento.ReceberArrendamento = receberArrendamento;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
                .Include(a => a.Habitacao)
                .Include(a => a.Locador)
                .Include(a => a.Imagens)
                .Include(a => a.EntregarArrendamento)
                .Include(a => a.EntregarArrendamento.Equipamentos)
                .Include(a => a.ReceberArrendamento)
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
            var arrendamento = await _context.Arrendamentos
                .Include(a=>a.EntregarArrendamento)
                .Include(a=>a.EntregarArrendamento)
                .Include( a=> a.EntregarArrendamento.Equipamentos)
                .Include( a=> a.ReceberArrendamento.Equipamentos)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (arrendamento != null)
            {
                foreach (var imagem in arrendamento.Imagens)
                {
                    _context.Imagens.Remove(imagem);
                }

                if(arrendamento.EntregarArrendamentoId != null)
                    _context.EntregarArrendamentos.Remove(arrendamento.EntregarArrendamento);
               

                if (arrendamento.ReceberArrendamentoId != null)
                    _context.ReceberArrendamentos.Remove(arrendamento.ReceberArrendamento);
                  

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
