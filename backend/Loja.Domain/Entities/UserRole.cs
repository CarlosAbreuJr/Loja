using Loja.Domain.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("UserRoles")]
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }//public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
