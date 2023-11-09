using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFolha.Models
{
    public class RecibosDePagamentoModel
    {
        [Key]
        public int Id_RP { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string DataEmissao { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string MesAnoRef { get; set; }
        [Required(ErrorMessage = "O salario bruto é obrigatorio")]
        public double SalarioBruto { get; set; }
        [Required(ErrorMessage = "A quantidade de horas extras é obrigatorio")]
        public int HorasExtras { get; set; }
        [Required(ErrorMessage = "O valor do desconto de INSS é obrigatorio")]
        public double DescontoINSS { get; set; }
        [Required(ErrorMessage = "O valor do desconto de IR é obrigatorio")]
        public double DescontoIR { get; set; }
        [Required(ErrorMessage = "O total dos vencimentos é obrigatorio")]
        public double TotalVencimentos { get; set; }//=> salarioBruto + HorasExtras;
        [Required(ErrorMessage = "O total dos descontos é obrigatorio")]
        public double TotalDescontos { get; set; }//=> DescontoINSS + DescontoIR;
        [Required(ErrorMessage = "O salario liquido é obrigatorio")]
        public double SalarioLiquido { get; set; }//=> TotalVencimentos - TotalDescontos
        public int Cod_Fun {get; set;}
        [ForeignKey("Cod_Fun")]
        public CadastroFuncionarioModel CadastroFuncionarioModel { get; set; }
    }
}
