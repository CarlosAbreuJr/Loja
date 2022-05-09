
using Loja.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("FormaPagamento")]
    public class FormaPagamento:EntityBase
    {
        public FormaPagamento()
        {
            //Parcelas = new HashSet<Parcelamento>();
        }
        
        [Column("Descricao", TypeName = "nvarchar", Order = 1)]
        [MaxLength(20), Required]
        public string Descricao { get; set; }
        
        public int Quantidade { get; set; }
        public bool ValorDeEntrada { get; set; }
        public decimal DescontoAcrescimo { get; set; }
        //public IEnumerable<Parcelamento> Parcelas { get; set; }
        public int DiasEntreParcelas { get; set; }
        public TipoPagamento TipoPagamento { get; set; }

    }
}