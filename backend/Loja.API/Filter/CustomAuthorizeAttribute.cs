using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Loja.API.Filter
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public CustomAuthorizeAttribute()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }

    }
}