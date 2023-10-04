using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Pomelo.EntityFrameworkCore.MySql.Query.Expressions.Internal;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ProjetoFolha.Models;

public class CadastroFuncionarioModel
{
    // Informações de Cadastro 

    //[Key]
   // [Required]
    public string Id { get; set; }

    //[Required(ErrorMessage = "O nome é obrigatório")]
    public string nome {  get; set; }

   // [Required(ErrorMessage = "O CPF é obrigatório")]
    public string cpf { get; set; }

   // [Required(ErrorMessage = "O setor é obrigatório ")]
    public string cargo { get; set; }
    //[Required(ErrorMessage = "A data é obrigatória")]
    public string dataAdmissao { get; set; }

    //[Required(ErrorMessage = "A CTPS é obrigatoria")]

    public string email { get; set; }

    public string senha { get; set; }

    public string sexoSelecionado { get; set; }

   


    
}
