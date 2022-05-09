using System.ComponentModel.DataAnnotations;

namespace Loja.API.Resources
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}
