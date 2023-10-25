namespace ProjetoFolha.Models
{
    public class RecibosDePagamentoModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string dataAdmissao { get; set; }
        public string CPF { get; set; }
        public string cargo { get; set; }
        public decimal salarioBruto { get; set; }
        public int HorasExtras { get; set; }
        public decimal DescontoINSS { get; set; }
        public decimal DescontoIR { get; set; }
        public decimal TotalVencimentos => salarioBruto + HorasExtras;
        public decimal TotalDescontos => DescontoINSS + DescontoIR;
        public decimal SalarioLiquido => TotalVencimentos - TotalDescontos;
    }
}
