using Kosplay.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kosplay.Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.User)                  
           .WithMany(x => x.Products)              
           .HasForeignKey(x => x.UserId)          
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Status)
           .WithMany(x => x.Products)
           .HasForeignKey(x => x.StatusId)
           .OnDelete(DeleteBehavior.Restrict);

           builder.HasOne(x => x.Category)
          .WithMany(x => x.Products)
          .HasForeignKey(x => x.CategoryId)
          .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
