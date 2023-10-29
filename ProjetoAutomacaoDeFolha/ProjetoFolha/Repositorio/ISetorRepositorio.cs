using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public interface ISetorRepositorio
    {
        SetorModel AdicionarSetor(SetorModel cadastrar);
        SetorModel ListarPorId(int id);
        List<SetorModel> BuscarTodos();

    }
}
