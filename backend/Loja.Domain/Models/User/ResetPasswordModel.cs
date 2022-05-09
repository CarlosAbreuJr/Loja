using Loja.Domain.Enuns;

namespace Loja.Domain.Models
{
    public class ResetPasswordModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public EnumNotificationType NotificationType { get; set; }

    }
}
