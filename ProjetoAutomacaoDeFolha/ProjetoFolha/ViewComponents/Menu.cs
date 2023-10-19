using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjetoFolha.Models;
using System.Threading.Tasks;

namespace ProjetoFolha.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessionUsuario)) return null;
            
            CadastroFuncionarioModel usuario = JsonConvert.DeserializeObject<CadastroFuncionarioModel>(sessionUsuario);
            return View(usuario);
        }
    }
}
