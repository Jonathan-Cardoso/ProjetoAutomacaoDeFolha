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
            return _context.RecibosDePagamentoModel.FirstOrDefault(x => x.Id_RP == id);
        }

        public RecibosDePagamentoModel ListarPorIdFunc(int id)
        {
            return _context.RecibosDePagamentoModel.FirstOrDefault(x => x.Cod_Fun == id);
        }

        public List<RecibosDePagamentoModel> BuscarTodosRecibosPorIdFunc(int id)
        {
            return _context.RecibosDePagamentoModel.Where(x => x.Cod_Fun == id).ToList();
        }

        public List<RecibosDePagamentoModel> BuscarTodosRecibos(int id)
        {
            return _context.RecibosDePagamentoModel.Where(x => x.Id_RP == id).ToList();
        }

        public List<RecibosDePagamentoModel> BuscarTodosRecibos()
        {
            return _context.RecibosDePagamentoModel.ToList();
        }

        public RecibosDePagamentoModel Gerar(RecibosDePagamentoModel gerar)
        {
            gerar.DataEmissao = DateTime.Now.ToString("dd/MM/yyyy");
            gerar.MesAnoRef = DateTime.Now.ToString("MM/yyyy");
            Console.WriteLine("Cadastro: " + gerar.ToString());
            _context.RecibosDePagamentoModel.Add(gerar);
            _context.SaveChanges();
            return gerar;
        }

        public CadastroFuncionarioModel ListarPorCodFun(int Id)
        {
            return _context.CadastroFuncionarioModel.FirstOrDefault(x => x.Cod_Fun == Id);
        }

        //public RecibosDePagamentoModel BuscarFolha(RecibosDePagamentoModel folha)
        //{
        //    RecibosDePagamentoModel folha = ListarPorId(cadastro.Cod_Fun);
        //    if (folha == null)
        //        throw new System.Exception("Houve um erro ao tentar buscar folha!");
        //}
    }
}
