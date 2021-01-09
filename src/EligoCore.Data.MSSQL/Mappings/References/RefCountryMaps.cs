using EligoCore.Domain.Entities.References;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EligoCore.Data.MSSQL.Mappings.References
{
    public class RefCountryMaps : IEntityTypeConfiguration<RefCountry>
    {
        public void Configure(EntityTypeBuilder<RefCountry> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
