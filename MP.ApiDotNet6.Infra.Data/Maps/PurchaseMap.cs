using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Compra");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Idcompra").UseIdentityColumn();
            builder.Property(x => x.PersonId).HasColumnName("Idpessoa");
            builder.Property(x => x.ProductId).HasColumnName("Idproduto");
            builder.Property(x => x.Date).HasColumnName("Datacompra");

            builder.HasOne(x => x.Person).WithMany(x => x.Purchases);

            builder.HasOne(x => x.Products).WithMany(x => x.Purchases);
        }
    }
}