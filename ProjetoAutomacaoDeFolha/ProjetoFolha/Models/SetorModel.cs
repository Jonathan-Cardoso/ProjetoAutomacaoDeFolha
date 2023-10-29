using System.ComponentModel.DataAnnotations;

namespace ProjetoFolha.Models
{
    public class SetorModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<CadastroFuncionarioModel> CadastroFuncionarioModels { get; set; }
    }
}
