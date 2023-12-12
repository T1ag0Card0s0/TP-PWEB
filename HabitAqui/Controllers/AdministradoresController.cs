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
using Microsoft.AspNetCore.Authorization;
using HabitAqui.ViewModels;
using SQLitePCL;

namespace HabitAqui.Controllers
{
    
    public class AdministradoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdministradoresController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }

        // GET: Administradores
        public async Task<IActionResult> Index()
        {
              return _context.Administradores != null ? 
                          View(await _context.Administradores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Administradores'  is null.");
        }

        // GET: Administradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .FirstOrDefaultAsync(m => m.AdministradorId == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        public IActionResult Filter(string locadorNome, string estado, string order)
        {
            var locadores = _context.Locadores.Include(l => l.ApplicationUser).ToList();
            ViewData["Locadores"] = locadores;

            if (locadorNome != null)
                locadores = _context.Locadores.Where(l => l.Nome == locadorNome).ToList();

            if (estado != null && estado.Equals("Ativo"))
                locadores = _context.Locadores.Where(l => l.EstadoDeSubscricao == true).ToList();


            if (estado != null && estado.Equals("Inativo"))
                locadores = _context.Locadores.Where(l => l.EstadoDeSubscricao == false).ToList();

            if (order != null && order.Equals("Crescente"))
                locadores = locadores.OrderBy(l => l.MediaAvaliacao).ToList();

            if (order != null && order.Equals("Decrescente"))
                locadores = locadores.OrderByDescending(l => l.MediaAvaliacao).ToList();

            return View("ListLocadores",locadores);
        }

        public IActionResult ListUsers()
        {
            var funcionarios = _context.Funcionarios.Include(f => f.Locador).Include(f => f.ApplicationUser).ToList();
            var gestores = _context.Gestores.Include(g => g.Locador).Include(g => g.ApplicationUser).ToList();
            var clientes = _context.Clientes.Include(g => g.ApplicationUser).ToList();

            var viewModel = new ListUsersViewModel
            {
                Funcionarios = funcionarios,
                Gestores = gestores,
                Clientes = clientes
            };

            return View(viewModel);
        }

        // Desativar locador
        public async Task<IActionResult> DesativarLocador(int id)
        {
            var locador = _context.Locadores.Where(l => l.LocadorId == id).FirstOrDefault();

            if (locador != null)
                locador.EstadoDeSubscricao = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListLocadores));
        }

        // Atvar locador
        public async Task<IActionResult> AtivarLocador(int id)
        {
            var locador = _context.Locadores.Where(l => l.LocadorId == id).FirstOrDefault();

            if (locador != null)
                locador.EstadoDeSubscricao = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListLocadores));
        }


        // GET: Administradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdministradorId,Name")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrador);
        }

        // GET: Administradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            return View(administrador);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdministradorId,Name")] Administrador administrador)
        {
            if (id != administrador.AdministradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.AdministradorId))
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
            return View(administrador);
        }

        // GET: Administradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .FirstOrDefaultAsync(m => m.AdministradorId == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Administradores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Administradores'  is null.");
            }
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador != null)
            {
                _context.Administradores.Remove(administrador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorExists(int id)
        {
          return (_context.Administradores?.Any(e => e.AdministradorId == id)).GetValueOrDefault();
        }

        public IActionResult ListLocadores()
        {

            var locadores = _context.Locadores.Include(l => l.ApplicationUser).ToList();
            ViewData["Locadores"] = locadores;
            return View(locadores);
        }
    }
}
