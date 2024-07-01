using DropShipping.Models;
using Microsoft.AspNetCore.Mvc;

namespace DropShipping.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
               
                if(ModelState.IsValid)
                {
                    if (loginModel.Login == "adm" && loginModel.Senha == "123")
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Por favor , tente novamente";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login , tente novamente , detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }

            
        }
    }
}
