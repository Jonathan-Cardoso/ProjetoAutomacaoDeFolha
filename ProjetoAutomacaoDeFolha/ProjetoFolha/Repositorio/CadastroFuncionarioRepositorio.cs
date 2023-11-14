using Microsoft.AspNetCore.Mvc;
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
            return _context.CadastroFuncionarioModel.FirstOrDefault(x => x.Cod_Fun == id);
        }

        public List<CadastroFuncionarioModel> BuscarTodos()
        {
            return _context.CadastroFuncionarioModel.ToList();
        }

        public List<SetorModel> BuscarSetores()
        {
            return _context.SetorModel.ToList();
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
            CadastroFuncionarioModel cadastroDB = ListarPorId(cadastro.Cod_Fun);
            if (cadastroDB == null)
                throw new System.Exception("Houve um erro na atualização do funcionario!");

            cadastroDB.nome = cadastro.nome;
            cadastroDB.email = cadastro.email;
            cadastroDB.cpf = cadastro.cpf;
            cadastroDB.dataAdmissao = cadastro.dataAdmissao;
            cadastroDB.dataAtualizacao = DateTime.Now;
            cadastroDB.senha = cadastro.senha;
            cadastroDB.ConfirmarSenha = cadastro.ConfirmarSenha;
            cadastroDB.cargo = cadastro.cargo;
            cadastroDB.salarioBruto = cadastro.salarioBruto;
            cadastroDB.sexoSelecionado = cadastro.sexoSelecionado;
            cadastroDB.Perfil = cadastro.Perfil;
            cadastroDB.Id_ST = cadastro.Id_ST;


            Console.WriteLine("Cadastro: " + cadastroDB.ToString());
            _context.CadastroFuncionarioModel.Update(cadastroDB);
            _context.SaveChanges();
            return cadastroDB;
        }

        public bool Apagar(int id)
        {
            CadastroFuncionarioModel cadastroDB = ListarPorId(id);

            if (cadastroDB == null) throw new Exception("Houve um erro na deleção do cadastro!");

            _context.CadastroFuncionarioModel.Remove(cadastroDB);
            _context.SaveChanges();

            return true;
        }
        public CadastroFuncionarioModel GetCadastroFuncionarioById(int cadastroFuncionarioId)
        {
            throw new NotImplementedException();
        }
    }
}
