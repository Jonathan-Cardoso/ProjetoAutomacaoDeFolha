using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public interface ICadastroFuncionarioRepositorio
    {
        CadastroFuncionarioModel ListarPorId(int id);
        List<CadastroFuncionarioModel> BuscarTodos();
        CadastroFuncionarioModel Adicionar(CadastroFuncionarioModel cadastro);
        CadastroFuncionarioModel Atualizar(CadastroFuncionarioModel cadastro);
        CadastroFuncionarioModel GetCadastroFuncionarioById(int cadastroFuncionarioId);
        List<SetorModel> BuscarSetores();
        bool Apagar(int id);
    }
}
