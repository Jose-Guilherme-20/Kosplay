
using Kosplay.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kosplay.Infra.Mappings
{
    public class DocumentMap : IEntityTypeConfiguration<DocumentEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentEntity> builder)
        {
            builder.ToTable("Document", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Extension)
               .HasColumnType("varchar")
               .IsRequired()
               .HasMaxLength(10);

            builder.Property(x => x.Url)
              .HasColumnType("varchar")
              .IsRequired()
              .HasMaxLength(3000);
        }
    }
    
    
}
