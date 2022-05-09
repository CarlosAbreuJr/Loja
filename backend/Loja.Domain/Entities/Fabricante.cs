
using Loja.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("Fabricantes")]
    public class Fabricantes : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Product> Produtos { get; set; }
    }
}


