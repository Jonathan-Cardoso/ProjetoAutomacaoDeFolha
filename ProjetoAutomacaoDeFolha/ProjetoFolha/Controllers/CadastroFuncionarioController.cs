using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Data;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;

namespace ProjetoFolha.Controllers
{

    
    public class CadastroFuncionarioController : Controller
    {
        private readonly ICadastroFuncionarioRepositorio _cadastroFuncionarioRepositorio;
        public CadastroFuncionarioController(ICadastroFuncionarioRepositorio cadastroFuncionarioRepositorio)
        {
            _cadastroFuncionarioRepositorio = cadastroFuncionarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CadastroFuncionarioModel cadastro)
        {
            Console.WriteLine("Cadastro" + cadastro);
            string sexo = cadastro.sexoSelecionado;
            _cadastroFuncionarioRepositorio.Adicionar(cadastro);
            return RedirectToAction("Index");

        }
    }
}
