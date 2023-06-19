

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain;

namespace MP.ApiDotNet6.Infra.Data;

public class PersonImageMap : IEntityTypeConfiguration<PersonImage>
{
    public void Configure(EntityTypeBuilder<PersonImage> builder)
    {
        builder.ToTable("pessoaimagem");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("idimagem").UseIdentityColumn();
        builder.Property(x => x.PersonId).HasColumnName("idpessoa");
        builder.Property(x => x.ImageBase).HasColumnName("imagebase");
        builder.Property(x => x.ImageUri).HasColumnName("imageurl");

        builder.HasOne(x => x.Person).WithMany(x => x.PersonImages);
    }
}
