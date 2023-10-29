using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public interface IRecibosDePagamentoRepositorio
    {
        RecibosDePagamentoModel ListarPorIdRecibo(int id);
        List<RecibosDePagamentoModel> BuscarTodosRecibos();
        RecibosDePagamentoModel Gerar(RecibosDePagamentoModel gerar);
    }
}
