
using Loja.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("Order")]
    public class Order:EntityBase
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Required]
        public decimal ValorParcela { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int DiasAtraso { get; set; }
        public decimal JurosDescontos { get; set; }
        public decimal ValorPago { get; set; }

        public int ClientsId { get; set; }
        [ForeignKey("ClientsId")]
        public Clients Clients { get; set; }

        public int OrderItemId { get; set; }
        [ForeignKey("OrderItemId")]
        public ICollection<OrderItem> OrderItems { get; set; }

        public int FormaPagamentoId { get; set; }
        [ForeignKey("FormaPagamentoId")]
        public FormaPagamento FormaPagamento { get; set; }



    }
}