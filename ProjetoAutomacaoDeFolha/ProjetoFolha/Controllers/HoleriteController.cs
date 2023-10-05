using Microsoft.AspNetCore.Mvc;

namespace ProjetoFolha.Controllers
{
    public class HoleriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
