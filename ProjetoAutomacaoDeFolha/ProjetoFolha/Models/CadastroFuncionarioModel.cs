using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Pomelo.EntityFrameworkCore.MySql.Query.Expressions.Internal;
using ProjetoFolha.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace ProjetoFolha.Models;

public class CadastroFuncionarioModel
{
    // Informações de Cadastro 

    [Key]
    public int Cod_Fun { get; set; }

   [Required(ErrorMessage = "O nome é obrigatório")]
    public string nome {  get; set; }

   [Required(ErrorMessage = "O CPF é obrigatório")]
    public string cpf { get; set; }

   [Required(ErrorMessage = "O setor é obrigatório ")]
    public string cargo { get; set; }
    [Required(ErrorMessage = "A data é obrigatória")]
    public string dataAdmissao { get; set; }

    [Required(ErrorMessage = "O email é obrigatorio")]
    [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
    public string email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatoria")]
    public string senha { get; set; }

    [Required(ErrorMessage = "A confirmação de senha é obrigatoria")]
    [NotMapped]
    public string ConfirmarSenha { get; set; }

    public string sexoSelecionado { get; set; }
    
    [Required(ErrorMessage = "O salario bruto é obrigatorio")]
    public double salarioBruto { get; set; }

    public bool SenhaValida(string Senha)  
    {
        return senha == Senha;
    }

    public DateTime dataCadastro { get; set; }
    
    public DateTime? dataAtualizacao { get; set; }

    [Required(ErrorMessage = "O tipo de perfil é obrigatorio")]
    public PerfilEnum Perfil { get; set; }
    public int Id_ST { get; set; }
    [ForeignKey("Id_ST")]
    public SetorModel SetorModel { get; set; }
    [NotMapped]
    public virtual ICollection<RecibosDePagamentoModel> Recibos { get; set; }

    [NotMapped]
    public RecibosDePagamentoModel recibosDePagamento { get; set; }

}
