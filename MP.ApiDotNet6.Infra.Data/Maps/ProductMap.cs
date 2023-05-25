using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("idproduto").UseIdentityColumn();
            builder.Property(x => x.CodeErp).HasColumnName("codeerp");
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Price).HasColumnName("preco");

            builder.HasMany(x => x.Purchases)
            .WithOne(p => p.Products)
            .HasForeignKey(x => x.ProductId);
        }
    }
}