using Loja.Domain.Entities;
using Loja.Domain.Models.Authentication;

namespace Loja.Uteis.Interfaces
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        RefreshToken TakeRefreshToken(string token);
        void RevokeRefreshToken(string token);
    }
}
