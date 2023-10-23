using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;
using System.Diagnostics;
using System.Text;
using ProjetoFolha.Helper;
using ProjetoFolha.Filters;

namespace ProjetoFolha.Controllers
{
    [UsuarioLogado]
    public class ConsultaBeneficioController : Controller
    {
        private readonly Helper.ISession _session;
        public ConsultaBeneficioController(ILoginViewRepositorio loginviewrepositorio, Helper.ISession session)
        {

            _session = session;
        }
            public IActionResult Index()
        {
            return View();
        }


    }


}
