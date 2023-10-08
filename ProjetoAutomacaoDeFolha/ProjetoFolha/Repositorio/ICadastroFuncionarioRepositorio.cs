using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public interface ICadastroFuncionarioRepositorio
    {
        List<CadastroFuncionarioModel> BuscarTodos();
        CadastroFuncionarioModel Adicionar(CadastroFuncionarioModel cadastro);
    }
}
