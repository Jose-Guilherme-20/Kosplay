

using Microsoft.AspNetCore.Identity;

namespace Kosplay.Domain.Models.Entity
{
    public class UserEntity : IdentityUser<int>
    {
        public ICollection<ProductEntity> Products { get; set; }
    }
}
