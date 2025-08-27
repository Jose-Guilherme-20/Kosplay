
using Kosplay.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kosplay.Infra.Mappings
{
    public class ProductImagesMap : IEntityTypeConfiguration<ProductImagesEntity>
    {
        public void Configure(EntityTypeBuilder<ProductImagesEntity> builder)
        {
            builder.ToTable("ProductImages", "dbo");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Document)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
