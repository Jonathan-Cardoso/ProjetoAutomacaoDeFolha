using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFolha.Models
{
    public class SetorModel
    {
        [Key]
        public int Id_ST { get; set; }
        public string Descricao { get; set; }
        [NotMapped]
        public virtual ICollection<CadastroFuncionarioModel> CadastroFuncionarioModel { get; set; }
    }
}
