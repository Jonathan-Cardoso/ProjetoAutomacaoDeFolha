using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Filters;

namespace ProjetoFolha.Controllers
{
    [UsuarioLogado]
    public class RecibosDePagamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
