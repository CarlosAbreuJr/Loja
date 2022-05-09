
using Loja.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("Grupos")]
    public class Grupos : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Product> Produtos { get; set; }
    }
}


