using Microsoft.AspNetCore.Mvc;

namespace ProjetoFolha.Controllers
{
    public class RecibosDePagamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
