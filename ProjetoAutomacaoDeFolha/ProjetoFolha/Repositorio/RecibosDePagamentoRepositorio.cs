using ProjetoFolha.Data;
using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public class RecibosDePagamentoRepositorio : IRecibosDePagamentoRepositorio
    {
        private readonly CadastroFuncionarioContext _context;

        public RecibosDePagamentoRepositorio(CadastroFuncionarioContext context)
        {
            _context = context;
        }

        public RecibosDePagamentoModel ListarPorIdRecibo(int id)
        {
            return _context.RecibosDePagamentoModel.FirstOrDefault(x => x.Id == id);
        }

        public List<RecibosDePagamentoModel> BuscarTodosRecibos()
        {
            return _context.RecibosDePagamentoModel.ToList();
        }

        public RecibosDePagamentoModel Gerar(RecibosDePagamentoModel gerar)
        {
            Console.WriteLine("Cadastro: " + gerar.ToString());
            _context.RecibosDePagamentoModel.Add(gerar);
            _context.SaveChanges();
            return gerar;
        }
    }
}
