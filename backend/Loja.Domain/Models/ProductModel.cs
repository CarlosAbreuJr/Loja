namespace Loja.Domain.Models
{
    public class ProductModel
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public decimal Quantity { get; set; }//Quantidade
        //public decimal SalesPrice { get; set; }//Preco Venda
        //public decimal ProfitMargin { get; set; }//Margem Lucro
        //public decimal Markup { get; set; }
        //public decimal CostPrice { get; set; }//Preco de Custo
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal MargemLucro { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal Estoque { get; set; }
        public decimal EstoqueMinimo { get; set; }
        public decimal EstoqueReposicao { get; set; }
        public decimal Markup { get; set; }
        public int GruposId { get; set; }
        public int FabricantesId { get; set; }
        //public Grupo Grupo { get; set; }
        //public Fabricante Fabricante { get; set; }
    }
}
