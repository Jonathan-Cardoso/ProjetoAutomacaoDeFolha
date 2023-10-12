using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public interface ICadastroFuncionarioRepositorio
    {
        CadastroFuncionarioModel BuscarPorLogin(string login);
        List<CadastroFuncionarioModel> BuscarTodos();
        CadastroFuncionarioModel Adicionar(CadastroFuncionarioModel cadastro);
    }
}
