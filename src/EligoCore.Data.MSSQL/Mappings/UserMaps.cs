using EligoCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EligoCore.Data.MSSQL.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.EmailAddress)
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(e => e.RefCityPlaceOfBirth)
                .WithMany()
                .HasForeignKey(e => e.RefCityIdPlaceOfBirth)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(e => e.RefCountryPlaceOfBirth)
                .WithMany()
                .HasForeignKey(e => e.RefCountryIdPlaceOfBirth)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
