using System.ComponentModel.DataAnnotations;

namespace ProjectPresentation.ViewModels
{
    public class RegisterViewModel
    {
        
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Second name is required")]
        [MaxLength(50)]
        public string SecondName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]

        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; } = null!;
        [Required(ErrorMessage = "Confirmation is required")]
        public bool IsConfirm { get; set; }
    }
}
