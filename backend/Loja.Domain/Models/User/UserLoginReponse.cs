namespace Loja.Domain.Models
{
    public class UserLoginReponse
    {
        public int UserStatus { get; set; } = 0;
        public string Messagem { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
