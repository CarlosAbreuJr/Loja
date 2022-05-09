
using Loja.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("ContasRe")]
    public class ContasRe:EntityBase
    {
        [Required]
        public decimal ValorParcela { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int DiasAtraso { get; set; }
        public decimal JurosDescontos { get; set; }
        public decimal ValorPago { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}