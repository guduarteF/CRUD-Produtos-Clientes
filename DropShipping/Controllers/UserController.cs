using DropShipping.Filters;
using DropShipping.Models;
using DropShipping.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DropShipping.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UserController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IProductRepositorio _produtoRepositorio;

        public UserController(IUsuarioRepositorio usuarioRepositorio, IProductRepositorio produtoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _produtoRepositorio = produtoRepositorio;
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

        public IActionResult Editar(int id)
        {
            UserModel usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UserModel usuario = _usuarioRepositorio.BuscarPorId(id);
            return View("Delete",usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso !";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult ListarProdutosPorUsuarioId(int id)
        {
            List<ProductModel> produtos = _produtoRepositorio.BuscarTodos(id);
            return PartialView("_ProdutosUsuario", produtos);
        }

        [HttpPost]
        public IActionResult Criar(UserModel usuario) 
        {
            try
            {
                if(ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário criado com sucesso !";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch(Exception erro)
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UserModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UserModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Name = usuarioSemSenhaModel.Name,
                        Email = usuarioSemSenhaModel.Email,
                        Login = usuarioSemSenhaModel.Login,
                        Perfil = usuarioSemSenhaModel?.Perfil
                    };

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso !";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                return RedirectToAction("Index");
            }
        }

    }
}
