using ProjetoFolha.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ProjetoFolha.Helper
{
    public class Session : ISession
    {   
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor _httpContext)
        {
            _httpContext = _httpContext;
        }

        public CadastroFuncionarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<CadastroFuncionarioModel>(sessaoUsuario);// transormar ele em cadastro funcionario model usando o DeserializeObject
        }

        public void CriarSessaoDoUsuario(CadastroFuncionarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);// Aqui ele está convertendo um objeto para um padrão Json para colocar em uma string 
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor); // Criando a Sessão e passando o valor 
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");// Para remover a sessão
        }
    }
}
