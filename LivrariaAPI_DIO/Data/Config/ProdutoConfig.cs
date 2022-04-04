using LivrariaAPI_DIO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaAPI_DIO.Data.Config
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable<Produto>("Produtos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar(60)");
            builder.HasIndex(x => x.Nome);
            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(x => x.Img)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Categoria)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");
            builder.HasIndex(x => x.Categoria);
        }
    }
}
