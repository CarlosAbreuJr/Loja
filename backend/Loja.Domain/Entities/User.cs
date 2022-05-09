using Loja.Domain.Entities.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("Users")]
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordTmp { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Documento { get; set; }
        public bool EmailIsValid { get; set; }
        public bool IsChangePassword { get; set; }
        public string Role { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();

    }
}
