using System.Diagnostics;
using Biblioteca.Models;
using Biblioteca.Data; // Adicione este using se necessário
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // 1. Declare o campo

        // 2. Injete o contexto no construtor
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var livros = await _context.Livros.ToListAsync();
            var avaliacoes = await _context.Avaliacoes.ToListAsync();

            var medias = livros.ToDictionary(
                l => l.LivroId,
                l =>
                {
                    var avs = avaliacoes.Where(a => a.LivroId == l.LivroId).ToList();
                    double media = avs.Any() ? avs.Average(a => a.Nota) : 0;
                    int qtd = avs.Count;
                    return (media, qtd);
                });

            ViewBag.MediasAvaliacoes = medias;
            return View(livros ?? new List<Livro>());
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
