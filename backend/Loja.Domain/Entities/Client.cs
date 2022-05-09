
using Loja.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("Clients")]
    public class Clients : EntityBase
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIe { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CidadeId { get; set; }
        public string UFId { get; set; }
        public string Cep { get; set; }
    }
}


