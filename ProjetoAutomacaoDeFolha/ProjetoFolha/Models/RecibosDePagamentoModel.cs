using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFolha.Models
{
    public class RecibosDePagamentoModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O salario bruto é obrigatorio")]
        public double SalarioBruto { get; set; }
        [Required]
        public int HorasExtras { get; set; }
        [Required]
        public double DescontoINSS { get; set; }
        [Required]
        public double DescontoIR { get; set; }
        [Required]
        public double TotalVencimentos { get; set; }//=> salarioBruto + HorasExtras;
        [Required]
        public double TotalDescontos { get; set; }//=> DescontoINSS + DescontoIR;
        [Required]
        public double SalarioLiquido { get; set; }//=> TotalVencimentos - TotalDescontos
        public int CadastroFuncionarioId { get; set; }
        public virtual CadastroFuncionarioModel CadastroFuncionario { get; set; }
    }
}
