using Loja.Domain.Entities.Base;

namespace Loja.Domain.Entities
{
    public class TipoPagamento : EntityBase
    {
        public string Descricao { get; set; }
        public bool BaixarConta { get; set; }

    }
}
