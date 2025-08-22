using Kosplay.Domain.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kosplay.Infra.Context
{
    public class KosplayDbContext
         : IdentityDbContext<UserEntity, RoleEntity, int,
             UserClaimEntity, UserRoleEntity, UserLoginEntity,
             RoleClaimEntity, UserTokenEntity>
    {
        public KosplayDbContext(DbContextOptions<KosplayDbContext> options)
            : base(options)
        {
        }

        // Suas entidades customizadas
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<ProductEntity> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Aplica as configurações do Identity (PK int, FKs, etc.)
            base.OnModelCreating(builder);

            // Aplica todas as configurações de Mappings do seu assembly
            builder.ApplyConfigurationsFromAssembly(typeof(KosplayDbContext).Assembly);
        }
    }
}

    

