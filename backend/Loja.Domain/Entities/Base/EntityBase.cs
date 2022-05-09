using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateIn { get;set; } = DateTime.Now;
        public DateTime? ChangeIn { get;set; }
    }
}
