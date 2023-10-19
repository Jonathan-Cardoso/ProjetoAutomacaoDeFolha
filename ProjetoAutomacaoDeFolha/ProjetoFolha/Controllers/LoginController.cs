using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;
using System.Diagnostics;
using System.Text;
using ProjetoFolha.Helper;

namespace ProjetoFolha.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginViewRepositorio _loginviewrepositorio;
        private readonly Helper.ISession _session;

        public LoginController(ILoginViewRepositorio loginviewrepositorio, Helper.ISession session)
        {
            _loginviewrepositorio = loginviewrepositorio;
            _session = session;

        }


        public IActionResult Index()
        {
            if (_session.BuscarSessaoDoUsuario() != null) 
                return RedirectToAction("Index", "Home");
            return View("../_ViewStart");
        }

        public IActionResult Sair()
        {
            _session.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
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
                            _session.CriarSessaoDoUsuario(usuario);
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
