using ProjetoFolha.Data;
using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public class CadastroFuncionarioRepositorio : ICadastroFuncionarioRepositorio
    {   
        private readonly CadastroFuncionarioContext _context;

        public CadastroFuncionarioRepositorio(CadastroFuncionarioContext context)
        {
            _context = context;
        }

        public CadastroFuncionarioModel BuscarPorLogin(string login)
        {
            return _context.CadastroFuncionarioModel.FirstOrDefault(x => x.email.ToLower() == login);

        }

        public List<CadastroFuncionarioModel> BuscarTodos()
        {
            return _context.CadastroFuncionarioModel.ToList();
        }

        public CadastroFuncionarioModel Adicionar(CadastroFuncionarioModel cadastro)
        {
            Console.WriteLine("Cadastro: " + cadastro.ToString());
            _context.CadastroFuncionarioModel.Add(cadastro);
            _context.SaveChanges();
            return cadastro;
        }
    }

}
