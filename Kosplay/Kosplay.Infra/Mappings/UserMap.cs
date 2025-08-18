
using Kosplay.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kosplay.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(u => u.RefreshToken)
                     .HasMaxLength(500)
                     .IsRequired(false);

            builder.Property(u => u.RefreshTokenExpiryTime)
                  .IsRequired();

            // relacionamento 1:N User -> Products
            builder.HasMany(u => u.Products)
                  .WithOne(p => p.User)
                  .HasForeignKey(p => p.UserId);
        }
    }
}
