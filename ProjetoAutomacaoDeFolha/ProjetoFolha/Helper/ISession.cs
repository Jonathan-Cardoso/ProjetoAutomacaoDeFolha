using ProjetoFolha.Models;

namespace ProjetoFolha.Helper
{
    public interface ISession
    {
        void CriarSessaoDoUsuario(CadastroFuncionarioModel usuario);
        void RemoverSessaoUsuario();
        CadastroFuncionarioModel BuscarSessaoDoUsuario();
    }
}
