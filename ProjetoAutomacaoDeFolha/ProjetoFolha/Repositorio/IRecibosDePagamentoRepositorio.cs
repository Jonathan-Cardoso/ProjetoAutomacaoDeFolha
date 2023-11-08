using ProjetoFolha.Models;

namespace ProjetoFolha.Repositorio
{
    public interface IRecibosDePagamentoRepositorio
    {
        RecibosDePagamentoModel ListarPorIdRecibo(int id);
        List<RecibosDePagamentoModel> BuscarTodosRecibos();

        CadastroFuncionarioModel ListarPorCodFun(int Id);
        RecibosDePagamentoModel Gerar(RecibosDePagamentoModel gerar);
    }
}
