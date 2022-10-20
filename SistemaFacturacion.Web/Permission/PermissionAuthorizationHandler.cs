using SistemaFacturacion.Application.Constants;
using SistemaFacturacion.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using SistemaFacturacion.Web.Permission;

namespace SistemaFacturacion.Web.Permission
{
    internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        
        public PermissionAuthorizationHandler()
        {

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
            {
                return;
            }
             var permissionss = context.User.Claims.Where(x => x.Type == CustomClaimTypes.Permission &&
                                                             x.Value == requirement.Permission &&
                                                             x.Issuer == "LOCAL AUTHORITY");
            if (permissionss.Any())
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}