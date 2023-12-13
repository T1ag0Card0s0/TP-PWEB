using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HabitAqui.Data;
using HabitAqui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace HabitAqui.Controllers
{
    [Authorize(Roles = "Admin,Cliente")]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(cliente.AvaliacoesHabitacao));
            ModelState.Remove(nameof(cliente.Arrendamentos));
            ModelState.Remove(nameof(cliente.ApplicationUser));

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ListUsers", "Administradores");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);

            var arrendamentos = _context.Arrendamentos.Include(a => a.Cliente).Where(a => a.ClienteId == id);
            if (arrendamentos.Any())
            {
                return RedirectToAction("ListUsers", "Administradores");
            }
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = _context.Clientes.Include(c => c.ApplicationUser).ToList();
            if (clientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Clientes'  is null.");
            }
            var cliente = clientes.Where(c=> c.ClienteId == id).FirstOrDefault();
            if (cliente != null)
            {
                var user = _context.Users.Find(cliente.ApplicationUser.Id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                }

                _context.Clientes.Remove(cliente);
            }
            await _context.SaveChangesAsync();
            if (User.IsInRole("Gestores"))
            {
                return RedirectToAction("ListEmployees", "Gestores");
            }else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("ListUsers", "Administradores");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.ClienteId == id)).GetValueOrDefault();
        }

        // metodo de pesquisa inicial
        [HttpGet]
        public IActionResult ListArrendamentos()
        {
            var habitacoes = _context.Arrendamentos
                .Include(h => h.Habitacao)
                .Include(h => h.Habitacao.Locador)
                .Include(h => h.Habitacao.Categoria)
                .AsQueryable();

            habitacoes = habitacoes.Where(h => h.Cliente.ApplicationUser.Email.Contains(User.Identity.Name));

            var resultado = habitacoes.ToList();

            return View("ListArrendamentos", resultado);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
