using Microsoft.AspNetCore.Mvc;
using ProjetoFolha.Filters;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;

namespace ProjetoFolha.Controllers
{
    [UsuarioLogado]
    public class RecibosDePagamentoController : Controller
    {

        private readonly IRecibosDePagamentoRepositorio _recibosDePagamentoRepositorio;
        private readonly ICadastroFuncionarioRepositorio _cadastroFuncionarioRepositorio;

        public RecibosDePagamentoController(IRecibosDePagamentoRepositorio recibosDePagamentoRepositorio)
        {
            _recibosDePagamentoRepositorio = recibosDePagamentoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GeradorDeHolerite()
        {
            return View();
        }
        /*public IActionResult GeradorDeHolerite(int id)
        {
            CadastroFuncionarioModel funcionario = _cadastroFuncionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }*/

        [HttpPost]
        public IActionResult GeradorDeHolerite(RecibosDePagamentoModel holerite)
        {
            if (ModelState.IsValid)
            {
                CadastroFuncionarioModel cadastroFuncionario = _cadastroFuncionarioRepositorio.GetCadastroFuncionarioById(holerite.CadastroFuncionarioId);

                if (cadastroFuncionario != null)
                {
                    // O CadastroFuncionarioId é válido, associe o Recibo ao funcionário.

                    holerite.CadastroFuncionario = cadastroFuncionario;
                    _recibosDePagamentoRepositorio.Gerar(holerite);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("CadastroFuncionarioId", "O CadastroFuncionarioId fornecido não é válido.");
                }
            }

            return View(holerite);
        }
    }
}
