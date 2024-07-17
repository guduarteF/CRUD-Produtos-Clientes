using DropShipping.Helper;
using DropShipping.Models;
using DropShipping.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace DropShipping.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // Se o usuario estiver logado, redirecionar para a home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult RedefinirSenha()
        {

            return View();
        }
        
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
               
                if(ModelState.IsValid)
                {
                    UserModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "A senha do usuário é invalida. Por favor , tente novamente";
                    }

                    TempData["MensagemErro"] = "Usuário e/ou senha invalido(s). Por favor , tente novamente";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login , tente novamente , detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }

            
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    UserModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        _usuarioRepositorio.Atualizar(usuario);

                        TempData["MensagemSucesso"] = $"Enviamos para o seu email cadastrado uma nova senha.";
                        return RedirectToAction("Index","Login");
                       
                    }

                    TempData["MensagemErro"] = "Não conseguimos redefinir sua senha. Por favor , verifique os dados informados";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha, tente novamente , detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
