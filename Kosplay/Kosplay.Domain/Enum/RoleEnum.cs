
using System.ComponentModel.DataAnnotations;

namespace Kosplay.Domain.Enum
{
    public enum RoleEnum
    {
        [Display(Name = "Admin")]
        Admin = 1,
        [Display(Name = "Comprador")]
        Vendedor = 2,
        [Display(Name = "Vendedor")]
        Comprador = 3
    }
}
