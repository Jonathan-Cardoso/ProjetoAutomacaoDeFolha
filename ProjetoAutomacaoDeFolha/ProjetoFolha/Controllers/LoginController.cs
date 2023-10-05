using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Models;
using System.Diagnostics;

namespace ProjetoFolha.Controllers
{
    public class LoginController : Controller
    {
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
            if(viewModel.Email == login && viewModel.Senha == passwd)
               return true;
            else
                return false;
        }
    }
}
