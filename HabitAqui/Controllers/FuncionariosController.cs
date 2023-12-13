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
using System.Numerics;
using FluentNHibernate.Conventions;

namespace HabitAqui.Controllers
{
    [Authorize(Roles = "Admin,Gestor, Funcionario")]
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FuncionariosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Habitacoes
        public async Task<IActionResult> Index()
        {
            var habitacoes = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).ToList();

            return View(habitacoes);
        }

        public async Task<IActionResult> ListHabitacoes()
        {
            var user = await _userManager.GetUserAsync(User);
            // Recupere o Funcionário com base no ID
            var funcionario = _context.Funcionarios.Include(f => f.Locador) // Inclua os locadores relacionados
            .FirstOrDefault(f => f.ApplicationUser.Id == user.Id);
            var locador = funcionario.Locador;

            var habitacoes = locador.Habitacoes.ToList();
            // se locador nao tiver nenhuma habitaçao IMPLEMENTAR

            return View(habitacoes);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        public async Task<IActionResult> EntregaHabitacao()
        {
            return View();
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioId))
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
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(m => m.ApplicationUser)
                .Include(m => m.Locador)
                .ThenInclude(locador => locador.Arrendamentos)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            if (funcionario.Locador.Arrendamentos != null)
            {
                if (!funcionario.Locador.Arrendamentos.IsEmpty())
                {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administradores");
                    }
                    return RedirectToAction("ListEmployees", "Gestores");
                }
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Funcionarios'  is null.");
            }
            var funcionario = await _context.Funcionarios
                .Include(m => m.ApplicationUser)
                .Include(m => m.Locador)
                .Include(m => m.Locador.Arrendamentos)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);

            if (funcionario == null) {
                return NotFound();
            }
            
            var appuser = funcionario.ApplicationUser;
            await _userManager.DeleteAsync(appuser);

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("ListUsers", "Administradores");
            }
            if (User.IsInRole("Gestor")) {
                return RedirectToAction("ListEmployees", "Gestores");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
          return (_context.Funcionarios?.Any(e => e.FuncionarioId == id)).GetValueOrDefault();
        }
    }
}
