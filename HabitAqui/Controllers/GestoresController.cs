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
                .FirstOrDefaultAsync(m => m.GestorId == id);
            if (gestor == null)
            {
                return NotFound();
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
                return Problem("Entity set 'ApplicationDbContext.Gestores'  is null.");
            }
            var gestor = await _context.Gestores.FindAsync(id);
            if (gestor != null)
            {
                _context.Gestores.Remove(gestor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestorExists(int id)
        {
            return (_context.Gestores?.Any(e => e.GestorId == id)).GetValueOrDefault();
        }

        public IActionResult ListEmployees()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            MyEmployees myEmployees = new MyEmployees();
            myEmployees.Funcionarios = _context.Funcionarios
                .Include(f => f.ApplicationUser)
                .ToList();
            myEmployees.Clientes = _context.Clientes
                .Include(c => c.ApplicationUser)
                .ToList();
            myEmployees.Gestores = _context.Gestores
                .Include(g => g.ApplicationUser)
                .Where(g => g.ApplicationUser.Email != email)
                .ToList();

            return View(myEmployees);
        }
        public async Task<IActionResult> ListAccomodations()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);

            // Carregar o Gestor com os Locadores e Habitacoes em uma única consulta
            Gestor gestor = await _context.Gestores
                .Include(g => g.Locadores)
                .ThenInclude(locador => locador.Habitacoes)
                .FirstOrDefaultAsync(g => g.ApplicationUser.Email == email);

            // Extrair todas as habitacoes diretamente, evitando o loop
            List<Habitacao> habitacoes = gestor.Locadores
                .SelectMany(locador => locador.Habitacoes)
                .ToList();

            return View(habitacoes);
        }

    }
}
