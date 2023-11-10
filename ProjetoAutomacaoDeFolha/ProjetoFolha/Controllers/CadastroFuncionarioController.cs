using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFolha.Data;
using ProjetoFolha.Filters;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjetoFolha.Controllers
{
    [UsuarioVerificacaoPerfil]
    public class CadastroFuncionarioController : Controller
    {
        private readonly ICadastroFuncionarioRepositorio _cadastroFuncionarioRepositorio;

        public CadastroFuncionarioController(
            ICadastroFuncionarioRepositorio cadastroFuncionarioRepositorio
        )
        {
            _cadastroFuncionarioRepositorio = cadastroFuncionarioRepositorio;
        }

        //CadastroFuncionarioModel teste = new CadastroFuncionarioModel();
        public IActionResult Index()
        {
            List<CadastroFuncionarioModel> Funcionarios =
                _cadastroFuncionarioRepositorio.BuscarTodos();
            return View(Funcionarios);
        }

        public IActionResult CadastroFuncionario()
        {
            return View();
        }

        public IActionResult EditarFuncionario(int id)
        {
            CadastroFuncionarioModel funcionario = _cadastroFuncionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }
        
        public IActionResult InativarFuncionario(int id)
        {
            CadastroFuncionarioModel funcionario = _cadastroFuncionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }

        public IActionResult DeletarCadastro(int id)
        {
            try
            {
                bool apagado = _cadastroFuncionarioRepositorio.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Contato apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu contato, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CadastroFuncionario(CadastroFuncionarioModel cadastro)
        {
            //Valida os campos do formulario
            if (
                string.IsNullOrEmpty(cadastro.nome)
                || string.IsNullOrEmpty(cadastro.senha)
                || string.IsNullOrEmpty(cadastro.email)
            )
            {
                ModelState.AddModelError(
                    "",
                    "Por favor, preencha todos os campos antes de cadastrar."
                );
                return View(cadastro); // Retorna a view com os dados preenchidos pelo usuário para que ele possa corrigir
            }
            Console.WriteLine("Cadastro" + cadastro);
            string senha = cadastro.senha;
            string encodedStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(senha)); // Criptografia da senha
            cadastro.senha = encodedStr;
            //string inputStr = Encoding.UTF8.GetString(Convert.FromBase64String(encodedStr));// discriptografia da senha
            string sexo = cadastro.sexoSelecionado;
            _cadastroFuncionarioRepositorio.Adicionar(cadastro);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditarFuncionario(CadastroFuncionarioModel cadastro)
        {
            if (
                string.IsNullOrEmpty(cadastro.nome)
                || string.IsNullOrEmpty(cadastro.senha)
                || string.IsNullOrEmpty(cadastro.email)
            )
            {
                ModelState.AddModelError(
                    "",
                    "Por favor, preencha todos os campos antes de cadastrar."
                );
                return View(cadastro); // Retorna a view com os dados preenchidos pelo usuário para que ele possa corrigir
            }
            Console.WriteLine("Cadastro" + cadastro);
            string senha = cadastro.senha;
            string encodedStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(senha)); // Criptografia da senha
            cadastro.senha = encodedStr;
            //string inputStr = Encoding.UTF8.GetString(Convert.FromBase64String(encodedStr));// discriptografia da senha
            string sexo = cadastro.sexoSelecionado;
            _cadastroFuncionarioRepositorio.Atualizar(cadastro);
            return RedirectToAction("Index");
        }

        public IActionResult hth()
        {
            List<SetorModel> setor =
                _cadastroFuncionarioRepositorio.BuscarSetores();
            return View(setor);
        } 
    }
}
