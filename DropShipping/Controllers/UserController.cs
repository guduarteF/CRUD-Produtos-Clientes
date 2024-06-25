using DropShipping.Models;
using DropShipping.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DropShipping.Controllers
{
    public class UserController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UserController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UserModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UserModel usuario) 
        {
            try
            {
                if(ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);

                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch(Exception erro)
            {
                return RedirectToAction("Index");
            }

            
        }

    }
}
