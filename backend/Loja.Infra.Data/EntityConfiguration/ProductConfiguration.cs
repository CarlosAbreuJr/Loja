//using Loja.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Loja.Infra.Data.EntityConfiguration
//{
//    public class ProductConfiguration : IEntityTypeConfiguration<Produto>
//    {
//        public void Configure(EntityTypeBuilder<Produto> builder)
//        {
//            builder.Property(t => t.Id)
//                //.HasField("id")
//                .HasPrecision(1, 1);
//                //.UsePropertyAccessMode(PropertyAccessMode.Field);
//            builder.HasKey(t => t.Id);

//            builder.Property(t => t.Descricao);
//            //.HasField("descricao");
//            builder.Property(t => t.Estoque);
//            //.HasField("estoque");
//            builder.Property(t => t.Nome);
//            //.HasField("nome");
//            builder.Property(t => t.EstoqueMinimo);
//                //.HasField("estoque_minimo");
//            builder.Property(t => t.EstoqueReposicao);
//            //.HasField("estoque_reposicao");
//            //builder.Property(t => t.FabricanteId);
//            ////.HasField("id_fabricante");
//            //builder.Property(t => t.GrupoId);
//            ////.HasField("GrupoId");
//            builder.Property(t => t.MargemLucro);
//            //.HasField("margem_lucro");
//            builder.Property(t => t.Markup);
//            //.HasField("markup");
//            builder.Property(t => t.PrecoCusto);
//            //.HasField("preco_custo");
//            builder.Property(t => t.PrecoVenda);
//            //.HasField("preco_venda");
//        }
//    }
//}
