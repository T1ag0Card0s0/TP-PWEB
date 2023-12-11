﻿using HabitAqui.Data;
using HabitAqui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;

namespace HabitAqui.Controllers
{
    [AllowAnonymous]
    [Authorize(Roles = "Admin,Cliente,Gestor, Funcionario")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if(User.IsInRole("Funcionario") || User.IsInRole("Gestor")){
                Locador locador = null;

                if (User.IsInRole("Funcionario"))
                {
                    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Funcionario funcionario = await _context.Funcionarios
                        .Include(f => f.Locador)
                        .FirstOrDefaultAsync(f => f.ApplicationUser.Id == userId);
                    if (funcionario != null)
                    {
                        locador = funcionario.Locador;
                    }
                }
                else if (User.IsInRole("Gestor"))
                {
                    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Gestor gestor = await _context.Gestores
                        .Include(g => g.Locador)
                        .FirstOrDefaultAsync(g => g.ApplicationUser.Id == userId);
                    if (gestor != null)
                    {
                        locador = gestor.Locador;
                    }
                }

                if (locador != null)
                {
                    // Use locador.LocadorId to filter data for the specific Locador
                    var categoriasWithCount = await _context.Categorias
                        .Include(c => c.Habitacao)
                        .Where(c => c.Habitacao.Any(h => h.Locador.LocadorId == locador.LocadorId))
                        .Select(c => new
                        {
                            Categoria = c.Nome,
                            Count = c.Habitacao.Count
                        })
                        .ToListAsync();

                    ViewBag.CategoriasWithCount = categoriasWithCount;

                    // Use locador.LocadorId to filter data for the specific Locador
                    var estadosCount = await _context.Arrendamentos
                        .Where(a => a.Locador.LocadorId == locador.LocadorId)
                        .GroupBy(a => a.Estado)
                        .Select(g => new { Estado = g.Key, Count = g.Count() })
                        .ToListAsync();

                    ViewBag.EstadosCount = estadosCount;

                    // Fetch monthly arrendamentos data
                    var monthlyArrendamentos = await _context.Arrendamentos
                        .Where(a => a.Locador.LocadorId == locador.LocadorId)
                        .GroupBy(a => new { Year = a.DataInicio.Year, Month = a.DataInicio.Month })
                        .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Count = g.Count() })
                        .ToListAsync();

                    ViewBag.MonthlyArrendamentos = monthlyArrendamentos;

                    var jsonSettings = new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                }
            }
            return View(await _context.Categorias.ToListAsync());
        }

        // metodo de pesquisa inicial
        [HttpPost]
        public IActionResult Search(string category, string local, DateTime start_date, DateTime end_date, int periodo)
        {
            var habitacoes = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).Include(h => h.Arrendamentos).AsQueryable();
            
            if(!string.IsNullOrEmpty(category) )
            {
                habitacoes = habitacoes.Where(h => h.Categoria.Nome.Contains(category));
            }
            if(!string.IsNullOrEmpty(local)) {
                habitacoes = habitacoes.Where(h => h.Localizacao.Contains(local));
            }
            if(start_date != default(DateTime))
            {
                habitacoes = habitacoes.Where(h => h.Arrendamentos.Any(a => a.DataInicio >= start_date));
            }
            if(start_date != default(DateTime))
            {
                habitacoes = habitacoes.Where(h => h.Arrendamentos.Any(a => a.DataFim <= end_date));
            }
            if(periodo != null && periodo > 0) {
                habitacoes = habitacoes.Where(h => h.PeriodoMinimoArrendamento >= periodo);
            }

            // Retrieve the list of Categoria names from the database
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();
            
            // Pass the list of Categoria names to the view
            ViewData["CategoriaNames"] = categoriaNames;
            var resultado = habitacoes.ToList();

            return View("Search", resultado);
        }

        public IActionResult ListaHabitacoes()
        {
            var habitacoes = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).Include(h => h.Arrendamentos).AsQueryable();

            // Retrieve the list of Categoria names from the database
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();

            // Pass the list of Categoria names to the view
            ViewData["CategoriaNames"] = categoriaNames;
            var resultado = habitacoes.ToList();

            return View("Search", resultado);
        }


        // metodo chamado para aplicar os filtros 
        [HttpPost]
        public IActionResult Filter(string selectedCategories, string? local, string? minPrice, string? maxPrice, string? locador)
        {
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();
            ViewData["CategoriaNames"] = categoriaNames;

            var habitacao = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).AsQueryable();


            if (locador != null)
            {
                habitacao = habitacao.Where(h => h.Locador.Nome.Contains(locador));
            }

            if (!string.IsNullOrEmpty(selectedCategories))
            {
                habitacao = habitacao.Where(h => selectedCategories.Contains(h.Categoria.Nome));
            }

            if (!string.IsNullOrEmpty(minPrice))
            {
                int price = int.Parse(minPrice);
                habitacao = habitacao.Where(h => h.Custo >= price);
            }

            if (!string.IsNullOrEmpty(maxPrice))
            {
                int price = int.Parse(maxPrice);
                habitacao = habitacao.Where(h => h.Custo <= price);
            }

            if (!string.IsNullOrEmpty(local))
            {
                habitacao = habitacao.Where(h => h.Localizacao.Contains(local));
            }

            var resultado = habitacao.ToList();

            return View("Search", resultado);
        }

        // metodo chamado para ordenar os resultados e retornar a nova lista
        [HttpPost]
        public async Task<IActionResult> OrderSearch(string orderby)
        {
            var habitacao = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).Include(h => h.Avaliacoes).AsQueryable();
            if (orderby != null)
            {
                // Verifique os parâmetros e determine a ordenação
                if (orderby.Equals("PrecoCrescente", StringComparison.OrdinalIgnoreCase))
                {
                    habitacao = habitacao.OrderBy(h => h.Custo); // Ordenar o preço de forma crescente
                }
                else if (orderby.Equals("PrecoDecrescente", StringComparison.OrdinalIgnoreCase))
                {
                    habitacao = habitacao.OrderByDescending(h => h.Custo); // Ordenar o preço de forma decrescente

                }
                else if (orderby.Equals("AvalicaoCrescente", StringComparison.OrdinalIgnoreCase))
                {
                    habitacao = habitacao.OrderBy(h => h.MediaAvaliacao); // Ordenar a avaliação de forma crescente
                }
                else if (orderby.Equals("AvaliacaoDecrescente", StringComparison.OrdinalIgnoreCase))
                {
                    habitacao = habitacao.OrderByDescending(h => h.MediaAvaliacao); // Ordenar a avaliação de forma decrescente
                }
            }
            // Retrieve the list of Categoria names from the database
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();

            // Pass the list of Categoria names to the view
            ViewData["CategoriaNames"] = categoriaNames;

            return View("Search", habitacao.ToList());
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}