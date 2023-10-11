using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;
using System.Diagnostics;

namespace ProjetoFolha.Controllers
{
    public class LoginController : Controller
    {
        /*private readonly ICadastroFuncionarioRepositorio _loginFuncionario;

        public LoginController(ICadastroFuncionarioRepositorio loginFuncionario)
        {
            _loginFuncionario = loginFuncionario;
            
        }*/


        private const string login = "a";
        private const string passwd = "a";
        private readonly IHttpContextAccessor _httpContextAccessor;



    

        public LoginController(IHttpContextAccessor httpContextAccessor)
        {   

            _httpContextAccessor = httpContextAccessor;
            
        }
        public IActionResult Index()
        {
            return View("../_ViewStart");
        }

        public IActionResult Logar(LoginViewModel viewModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            if (session != null)
            {
                var isAuthenticated = session.GetString("IsAuthenticated");
            }
            var auth = LoginSimulado(viewModel);
            if (auth)
            {
                session?.SetString("User", "Admin");
                session?.SetInt32("UserId", 1);
                session?.SetString("IsAuthenticated", "true");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                session?.Clear();
                return RedirectToAction("Index", "Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private bool LoginSimulado(LoginViewModel viewModel)
        {

            //var user = loginFuncionario; //SingleOrDefault(u => u.Email == ViewModel.Email && u.Senha == ViewModel.Senha);
            //return user != null;
            if (viewModel.Email == login && viewModel.Senha == passwd)
               return true;
             else
                return false;
        }

        /*private bool LoginSimulado(LoginViewModel viewModel)
        {
            login = viewModel.Email;
            passwd = viewModel.Senha;
           if (loginFuncionario.BuscarPorLogin() == login && viewModel.Senha == passwd)
                return true;
            else
                return false;
            
        }*/
    }
}
