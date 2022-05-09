
using Loja.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    [Table("Produtos")]
    public class Product:EntityBase
    {
        //public int Id { get; set; }
        [Column("Nome", TypeName = "nvarchar", Order = 1)]
        [MaxLength(20)]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal MargemLucro { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal Estoque { get; set; }
        public decimal EstoqueMinimo { get; set; }
        public decimal EstoqueReposicao { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal Markup { get; set; }
        [NotMapped]
        public string ExemploCampoNaoMapeado { get; set; }
        //[ForeignKey("Grupo")]// este ou o annotation debaixo
        public int? GruposId { get; set; }
        [ForeignKey("GruposId")]
        public Grupos Grupo { get; set; }
        //public virtual Grupo Grupo { get; set; }

        public int? FabricantesId { get; set; }
        [ForeignKey("FabricantesId")]
        public Fabricantes Fabricantes { get; set; }
        //public virtual Fabricante Fabricante { get; set; }
    }
}



//usando em campo chave: [DatabaseGenerated(DatabaseGeneratedOption.None)] não adicionar valor (Não é autoincremento), mesmo que .ValueGeneratedNever(); em Fluente API
//usado em propriedade : [DatabaseGenerated(DatabaseGeneratedOption.Identity)] campo de identidade o valor é inserido pelo entity, não pode ser alterado, mesmo que .ValueGeneratedOnAdd(); em Fluente API
//usado em propriedade : [DatabaseGenerated(DatabaseGeneratedOption.Computed)] valor é inserido e atualizado automaticamente, para que funcione é necessário adicionar .HasDefaultValueSql("GETDATE()"); na propriedade em Fluente API

