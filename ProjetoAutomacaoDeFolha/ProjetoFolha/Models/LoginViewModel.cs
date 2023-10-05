using System.ComponentModel.DataAnnotations;

namespace ProjetoFolha.Models
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
