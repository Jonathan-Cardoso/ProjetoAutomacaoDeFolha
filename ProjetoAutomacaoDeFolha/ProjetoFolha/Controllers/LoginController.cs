using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;
using System.Diagnostics;
using System.Text;

namespace ProjetoFolha.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginViewRepositorio _loginviewrepositorio;

        public LoginController(ILoginViewRepositorio loginviewrepositorio)
        {
            _loginviewrepositorio = loginviewrepositorio;

        }

        public IActionResult Index()
        {
            return View("../_ViewStart");
        }

        public IActionResult Logar(LoginViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    CadastroFuncionarioModel usuario = _loginviewrepositorio.BuscarPorLogin(viewModel.Email);
                    if (usuario != null)
                    {

                        if (usuario.SenhaValida(Convert.ToBase64String(Encoding.UTF8.GetBytes(viewModel.Senha))))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválidos(s). Por favor, tente novamente.";
                }

                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente";
                return RedirectToAction("Index", "Login");
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
