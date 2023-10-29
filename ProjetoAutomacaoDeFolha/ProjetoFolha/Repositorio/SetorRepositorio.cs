using ProjetoFolha.Data;
using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public class SetorRepositorio : ISetorRepositorio
    {

        private readonly CadastroFuncionarioContext _context;

        public SetorRepositorio(CadastroFuncionarioContext context)
        {
            _context = context;
        }

        public SetorModel AdicionarSetor(SetorModel cadastrar)
        {
            _context.SetorModel.Add(cadastrar);
            _context.SaveChanges();
            return cadastrar;
        }
    }
}
