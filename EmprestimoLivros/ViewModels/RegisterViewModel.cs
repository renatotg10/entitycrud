using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.ViewModels
{
    //ViewModel ->  It acts as an abstraction of the view and is responsible for exposing data and commands to the view
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmPassword { get; set; }
    }
}
