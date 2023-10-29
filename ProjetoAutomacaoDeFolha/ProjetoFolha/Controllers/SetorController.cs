using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjetoFolha.Models;
using ProjetoFolha.Repositorio;

namespace ProjetoFolha.Controllers
{
    public class SetorController : Controller
    {

        private readonly ISetorRepositorio _setorRepositorio;

        public SetorController(ISetorRepositorio setorRepositorio)   
        {
            _setorRepositorio = setorRepositorio;
        }

        public IActionResult CadastrarSetor()
        {
            return View();
        }

        /*public IActionResult CadastrarSetor()
        {
            List<SetorModel> setores =
                _setorRepositorio.BuscarTodos();
            return View(setores);
        }*/

        [HttpPost]
        public IActionResult CadastroSetor(SetorModel setor)
        {
            
            try
            {
                
                
                
                if (setor.Descricao != null)
                {   
                    
                    _setorRepositorio.AdicionarSetor(setor);
                    TempData["MensagemSucesso"] = $"Setor cadastrado.";
                    return RedirectToAction("CadastrarSetor");
                    
                }
                

                return RedirectToAction("CadastrarSetor");

            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu setor, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("CadastrarSetor");
            }

        }

    }
}
