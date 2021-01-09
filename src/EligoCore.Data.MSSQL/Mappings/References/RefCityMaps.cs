using EligoCore.Domain.Entities.References;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EligoCore.Data.MSSQL.Mappings.References
{
    public class RefCityMaps : IEntityTypeConfiguration<RefCity>
    {
        public void Configure(EntityTypeBuilder<RefCity> builder)
        {
            builder.HasKey(p => p.Id);
                
            builder.Property(p => p.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasOne(e => e.RefCountry)
                .WithMany()
                .HasForeignKey(e => e.RefCountryID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
