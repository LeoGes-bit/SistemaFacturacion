using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SistemaFacturacion.Infrastructure.Data.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
