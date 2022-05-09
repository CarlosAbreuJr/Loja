using Loja.Domain.Entities;
using System.Collections.Generic;

namespace Loja.Domain.Models
{
    public class FormaPagamentoModel{
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public bool ValorDeEntrada { get; set; }
        public decimal DescontoAcrescimo { get; set; }
        public IEnumerable<Parcelamento> Parcelas { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
    }
}
