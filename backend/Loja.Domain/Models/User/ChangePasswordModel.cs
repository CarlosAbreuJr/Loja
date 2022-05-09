using System.ComponentModel.DataAnnotations;

namespace Loja.Domain.Models.User
{
    public class ChangePasswordModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string OldPassword { get; set; }
        [StringLength(100, ErrorMessage = "O campo {0} deve ter pelo menos {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [StringLength(100, ErrorMessage = "O campo {0} deve ter pelo menos {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "A senha não confere.")]
        public string NewPasswordConfirm { get; set; }

    }
}
