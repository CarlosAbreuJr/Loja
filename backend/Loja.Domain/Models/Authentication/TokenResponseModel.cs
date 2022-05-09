using Loja.Domain.Enuns;
using Loja.Domain.Models.Shared;

namespace Loja.Domain.Models.Authentication
{
    public class TokenResponse : ResponseBase<LoginResponse>
    {
        public TokenResponse(bool success, LoginResponse data) : base(success, data)
        {
        }
    }

    public class LoginResponse
    {
        //public AccessToken Token { get; set; }
        public AccessTokenResource Token { get; set; }
        public EnumStatusUser UserStatus { get; set; }
        public string Message { get; set; }


    }

}
