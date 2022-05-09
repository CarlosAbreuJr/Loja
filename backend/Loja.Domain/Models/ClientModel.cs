namespace Loja.Domain.Models
{
    public class ClientModel : IEndereco
    {
        public int Id { get; set; }
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
