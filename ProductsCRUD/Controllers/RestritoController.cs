using DropShipping.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DropShipping.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
