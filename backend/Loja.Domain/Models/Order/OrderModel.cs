using Loja.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Loja.Domain.Models
{

    public class OrderModel
    {
        public int Id { get; set; } 
        public decimal ValorParcela { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int DiasAtraso { get; set; }
        public decimal JurosDescontos { get; set; }
        public decimal ValorPago { get; set; }
        public ClientModel Client { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }

        public FormaPagamento FormaPagamento { get; set; }

    }
}
