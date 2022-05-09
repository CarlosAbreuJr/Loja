
using Loja.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("OrderItem")]
    public class OrderItem:EntityBase
    {
        public int ProductId { get; set; }

        [Column("Descricao", TypeName = "nvarchar", Order = 1)]
        [MaxLength(20), Required]
        public string Descricao { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal JurosDescontos { get; set; }
        public decimal SubTotalUnitario { get; set; }
        public decimal Quantidade { get; set; }
        public decimal TotalItem { get; set; }

        public ICollection<Order> Order { get; set; }

    }
}