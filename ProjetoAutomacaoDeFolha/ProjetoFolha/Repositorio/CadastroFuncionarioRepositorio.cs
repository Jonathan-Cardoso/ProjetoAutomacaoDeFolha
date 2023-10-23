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


        public CadastroFuncionarioModel ListarPorId(int id)
        {
            return _context.CadastroFuncionarioModel.FirstOrDefault(x => x.Id == id);    
        }

        public List<CadastroFuncionarioModel> BuscarTodos()
        {
            return _context.CadastroFuncionarioModel.ToList();
        }

        public CadastroFuncionarioModel Adicionar(CadastroFuncionarioModel cadastro)
        {
            cadastro.dataCadastro = DateTime.Now;
            Console.WriteLine("Cadastro: " + cadastro.ToString());
            _context.CadastroFuncionarioModel.Add(cadastro);
            _context.SaveChanges();
            return cadastro;
        }

        public CadastroFuncionarioModel Atualizar(CadastroFuncionarioModel cadastro)
        {

            CadastroFuncionarioModel cadastroDB = ListarPorId(cadastro.Id);
            if (cadastroDB == null) throw new System.Exception("Houve um erro na atualização do funcionario!");

            cadastroDB.nome = cadastro.nome;
            cadastroDB.email = cadastro.email;
            cadastroDB.cpf = cadastro.cpf;
            cadastroDB.dataAdmissao = cadastro.dataAdmissao;
            cadastroDB.dataAtualizacao = DateTime.Now;
            cadastroDB.senha = cadastro.senha;
            cadastroDB.ConfirmarSenha = cadastro.ConfirmarSenha;
            cadastroDB.cargo = cadastro.cargo;
            cadastroDB.salarioBruto = cadastro.salarioBruto;;
            cadastroDB.sexoSelecionado = cadastro.sexoSelecionado;
            cadastroDB.Perfil = cadastro.Perfil;

            Console.WriteLine("Cadastro: " + cadastroDB.ToString());
            _context.CadastroFuncionarioModel.Update(cadastroDB);
            _context.SaveChanges();
            return cadastroDB;
        }

    }

}
