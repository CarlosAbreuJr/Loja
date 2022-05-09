using Loja.Domain.Entities;
using Loja.Domain.Enuns;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Loja.Domain.Models
{
    public class CreateUserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter pelo menos {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public string Documento { get; set; }
        //public string Role { get; set; }
        //public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();

    }

    public class CreateUserNoPassModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public string Documento { get; set; }

        public EnumNotificationType NotificationType { get; set; }
        //public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();

    }
}
