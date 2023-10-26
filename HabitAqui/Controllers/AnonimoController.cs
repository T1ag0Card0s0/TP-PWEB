using HabitAqui.Data;
using HabitAqui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitAqui.Controllers
{
    public class AnonimoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AnonimoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(List<Habitacao> habitacoes)
        {
            // Se habitacoes for nulo (ou seja, nenhum resultado de pesquisa), carrega todas as habitacoes
            if (habitacoes == null || !habitacoes.Any())
            {
                habitacoes = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).ToList();
            }
            // Retrieve the list of Categoria names from the database
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();

            // Pass the list of Categoria names to the view
            ViewData["CategoriaNames"] = categoriaNames;
            return View(habitacoes);
        }
        // metodo chamado para aplicar os filtros e retornar a nova lista para o Index
        [HttpPost]
        public IActionResult Filter(string[] SelectedCategories, string? locador)
        {
            // Retrieve the list of Categoria names from the database
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();

            // Pass the list of Categoria names to the view
            ViewData["CategoriaNames"] = categoriaNames;
            var habitacao = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).AsQueryable();


            if (locador != null)
            {
                habitacao = habitacao.Where(h => h.Locador.Nome.Contains(locador));
            }

            if (SelectedCategories != null && SelectedCategories.Length > 0)
            {
                habitacao = habitacao.Where(h => SelectedCategories.Contains(h.Categoria.Nome));
            }

            var resultado = habitacao.ToList();


            return View("Index", resultado);
        }
        // metodo chamado para ordenar os resultados e retornar a nova lista
        [HttpPost]
        public async Task<IActionResult> OrderSearch(string preco, string avaliacao)
        {

            var habitacao = _context.Habitacoes.Include(h => h.Categoria).Include(h => h.Locador).Include(h => h.Avaliacoes).AsQueryable();
            if (preco != null)
            {
                // Verifique os parâmetros e determine a ordenação
                if (preco.Equals("crescente", StringComparison.OrdinalIgnoreCase))
                {
                    habitacao = habitacao.OrderBy(h => h.Custo); // Ordenar o preço de forma crescente
                }
                else if (preco.Equals("decrescente", StringComparison.OrdinalIgnoreCase))
                {
                    habitacao = habitacao.OrderByDescending(h => h.Custo); // Ordenar o preço de forma decrescente
                }
            }
            if (avaliacao != null)
            {
                if (avaliacao.Equals("crescente", StringComparison.OrdinalIgnoreCase))
                {
                    habitacao = habitacao.OrderBy(h => h.MediaAvaliacao); // Ordenar a avaliação de forma crescente
                }
                else if (avaliacao.Equals("decrescente", StringComparison.OrdinalIgnoreCase))
                {
                    habitacao = habitacao.OrderByDescending(h => h.MediaAvaliacao); // Ordenar a avaliação de forma decrescente
                }
            }
            // Retrieve the list of Categoria names from the database
            var categoriaNames = _context.Categorias.Select(c => c.Nome).ToList();

            // Pass the list of Categoria names to the view
            ViewData["CategoriaNames"] = categoriaNames;

            return View("Index", habitacao.ToList());
        }
    }
}
