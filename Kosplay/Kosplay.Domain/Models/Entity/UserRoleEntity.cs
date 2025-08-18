
using Microsoft.AspNetCore.Identity;

namespace Kosplay.Domain.Models.Entity
{
    public class UserRoleEntity : IdentityUserRole<int> { }
    public class UserClaimEntity : IdentityUserClaim<int> { }
    public class UserLoginEntity : IdentityUserLogin<int> { }
    public class RoleClaimEntity : IdentityRoleClaim<int> { }
    public class UserTokenEntity : IdentityUserToken<int> { }
    public class RoleEntity : IdentityRole<int> { }
}
