using DropShipping.Data;
using DropShipping.Filters;
using DropShipping.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DropShipping.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Produtos()
        {
            return View();
        }

        public IActionResult EditarProduto()
        {
            return View();
        }

        public IActionResult AdicionarProduto()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult AdicionarProduto() { }
        //{

        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
