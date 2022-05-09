using Loja.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Loja.Domain.Entities
{
    public class OrderRecebimento : EntityBase
    {
        public OrderRecebimento()
        {
            Order = new HashSet<Order>();
        }

        public string PedidosId { get; set; }
        public string ClienteId { get; set; }
        public string FormaPagamentoId { get; set; }
        public string UsuarioId { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal ValorPago { get; set; }
        public int QuantidadeParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime? DataPagamento { get; set; }
        public User Usuario { get; set; }
        public ICollection<Order> Order { get; set; }

    }

}
