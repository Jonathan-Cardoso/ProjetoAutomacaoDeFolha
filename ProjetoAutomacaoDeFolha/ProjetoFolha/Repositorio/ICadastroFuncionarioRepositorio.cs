using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public interface ICadastroFuncionarioRepositorio
    {
        CadastroFuncionarioModel BuscarPorLogin(string login);
        CadastroFuncionarioModel ListarPorId(int id);
        List<CadastroFuncionarioModel> BuscarTodos();
        CadastroFuncionarioModel Adicionar(CadastroFuncionarioModel cadastro);
        CadastroFuncionarioModel Atualizar(CadastroFuncionarioModel cadastro);
    }
}
