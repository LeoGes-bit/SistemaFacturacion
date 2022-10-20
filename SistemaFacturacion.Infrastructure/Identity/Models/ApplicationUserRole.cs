using Microsoft.AspNetCore.Identity;
using SistemaFacturacion.Infrastructure.Identity.Models;

namespace SistemaFacturacion.Infrastructure.Data.Identity.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
