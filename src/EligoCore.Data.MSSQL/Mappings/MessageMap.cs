using EligoCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EligoCore.Data.MSSQL.Mappings
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Subject)
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(p => p.Body)
                .IsRequired();
        }
    }
}
