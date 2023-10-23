using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Filters;

namespace ProjetoFolha.Controllers
{
    [UsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
