using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nome Completo")]
        [StringLength(100, ErrorMessage = "O nome deve ter entre {2} e {1} caracteres.", MinimumLength = 20)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "O CPF deve ter {1} caracteres.", MinimumLength = 11)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "O CPF deve ter entre {2} e {1} caracteres.", MinimumLength = 8)]
        [Display(Name = "Celular")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [Compare("Password", ErrorMessage = "A senha e confirmação devem ser iguais.")]
        public string ConfirmPassword { get; set; }
    }
}