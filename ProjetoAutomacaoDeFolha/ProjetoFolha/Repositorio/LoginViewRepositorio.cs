using ProjetoFolha.Data;
using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public class LoginViewRepositorio : ILoginViewRepositorio
    {
        private readonly CadastroFuncionarioContext _context;

        public LoginViewRepositorio(CadastroFuncionarioContext context)
        {
            _context = context;
        }

        public CadastroFuncionarioModel BuscarPorLogin(string login)
        {
            return _context.CadastroFuncionarioModel.FirstOrDefault(
                x => x.email.ToUpper() == login.ToUpper()
            );
        }
    }
}
