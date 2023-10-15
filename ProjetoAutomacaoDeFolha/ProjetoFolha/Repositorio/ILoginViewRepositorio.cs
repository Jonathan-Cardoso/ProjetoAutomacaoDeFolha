using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public interface ILoginViewRepositorio
    {
        CadastroFuncionarioModel BuscarPorLogin(string login);
    }
}
