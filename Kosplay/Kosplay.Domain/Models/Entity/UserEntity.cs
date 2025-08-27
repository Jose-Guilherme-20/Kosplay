

using Microsoft.AspNetCore.Identity;

namespace Kosplay.Domain.Models.Entity
{
    public class UserEntity : IdentityUser<int>
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
    }
}
