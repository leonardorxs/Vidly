using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Nome Completo")]
        [StringLength(100, ErrorMessage = "O nome deve ter, ao menos, {2} caracteres", MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [StringLength(11, ErrorMessage = "O CPF deve ter {1} caracteres.", MinimumLength = 11)]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Celular")]
        [StringLength(9, ErrorMessage = "O CPF deve ter entre {2} e {1} caracteres.", MinimumLength = 8)]
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