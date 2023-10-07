using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Data;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;
using System.Text;

namespace ProjetoFolha.Controllers
{

    
    public class CadastroFuncionarioController : Controller
    {
        private readonly ICadastroFuncionarioRepositorio _cadastroFuncionarioRepositorio;
        public CadastroFuncionarioController(ICadastroFuncionarioRepositorio cadastroFuncionarioRepositorio)
        {
            _cadastroFuncionarioRepositorio = cadastroFuncionarioRepositorio;
        }
        CadastroFuncionarioModel teste = new CadastroFuncionarioModel();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CadastroFuncionarioModel cadastro)
        {
            Console.WriteLine("Cadastro" + cadastro);
            string senha = cadastro.senha;
            string encodedStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(senha));// Criptografia da senha
            cadastro.senha = encodedStr;
            //string inputStr = Encoding.UTF8.GetString(Convert.FromBase64String(encodedStr));// discriptografia da senha 
            string sexo = cadastro.sexoSelecionado;
            _cadastroFuncionarioRepositorio.Adicionar(cadastro);
            return RedirectToAction("Index");

        }
    }
}
