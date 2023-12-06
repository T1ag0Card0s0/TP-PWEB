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
using System.Security.Claims;
using HabitAqui.ViewModels;
using FluentNHibernate.Conventions;

namespace HabitAqui.Controllers
{
    [Authorize(Roles = "Admin,Gestor")]
    public class GestoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GestoresController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Gestores
        public async Task<IActionResult> Index()
        {
            return _context.Gestores != null ?
                        View(await _context.Gestores.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Gestores'  is null.");
        }

        // GET: Gestores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gestores == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestores
                .FirstOrDefaultAsync(m => m.GestorId == id);
            if (gestor == null)
            {
                return NotFound();
            }

            return View(gestor);
        }

        // GET: Gestores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gestores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GestorId")] Gestor gestor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gestor);
        }

        // GET: Gestores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gestores == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestores.FindAsync(id);
            if (gestor == null)
            {
                return NotFound();
            }
            return View(gestor);
        }

        // POST: Gestores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GestorId")] Gestor gestor)
        {
            if (id != gestor.GestorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestorExists(gestor.GestorId))
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
            return View(gestor);
        }

        // GET: Gestores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gestores == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestores
                .Include(m => m.ApplicationUser)
                .Include(m => m.Locador)
                .ThenInclude(locador => locador.Arrendamentos)
                .FirstOrDefaultAsync(m => m.GestorId == id);

            if (gestor == null)
            {
                return NotFound();
            }

            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (gestor.ApplicationUser.Id == loggedInUserId)
            {
                return Forbid();
            }
            
            if (gestor.Locador.Arrendamentos != null) {
                if (!gestor.Locador.Arrendamentos.IsEmpty()) {
                    return Forbid();
                }
            }
            return View(gestor);
        }

        // POST: Gestores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gestores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Gestores' is null.");
            }

            var gestor = await _context.Gestores
                .Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.GestorId == id);

            if (gestor == null)
            {
                return NotFound();
            }

            var appuser = gestor.ApplicationUser;
            await _userManager.DeleteAsync(appuser);

            _context.Gestores.Remove(gestor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListEmployees));
        }


        private bool GestorExists(int id)
        {
            return (_context.Gestores?.Any(e => e.GestorId == id)).GetValueOrDefault();
        }

        public IActionResult ListEmployees()
        {
            var funcionarios = _context.Funcionarios.Include(f => f.Locador).Include(f => f.ApplicationUser).ToList();
            var gestores = _context.Gestores.Include(g => g.Locador).Include(g => g.ApplicationUser).ToList();
            var locadores = _context.Locadores.Include(l => l.ApplicationUser).ToList();
            var clientes = _context.Clientes.Include(c => c.ApplicationUser).ToList();

            var viewModel = new ListEmployeesViewModel
            {
                Funcionarios = funcionarios,
                Gestores = gestores,
                Clientes = clientes,
                Locadores = locadores
            };

            return View(viewModel);
        }
        public async Task<IActionResult> Ativar(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Ativo = true;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(ListEmployees));
        }

        public async Task<IActionResult> Desativar(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Ativo = false;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(ListEmployees));
        }

    }


}
