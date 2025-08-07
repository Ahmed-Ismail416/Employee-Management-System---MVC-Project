using System.ComponentModel.DataAnnotations;

namespace ProjectPresentation.Controllers
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
