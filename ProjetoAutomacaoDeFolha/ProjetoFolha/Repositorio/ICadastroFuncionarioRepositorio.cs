using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public interface ICadastroFuncionarioRepositorio
    {
        CadastroFuncionarioModel Adicionar(CadastroFuncionarioModel cadastro);
    }
}
