namespace Loja.Domain.Models
{
    public interface IEndereco
    {
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
