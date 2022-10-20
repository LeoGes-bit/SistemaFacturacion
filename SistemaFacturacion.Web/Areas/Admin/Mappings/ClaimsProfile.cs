using SistemaFacturacion.Web.Areas.Admin.Models;
using AutoMapper;
using System.Security.Claims;

namespace SistemaFacturacion.Web.Areas.Admin.Mappings
{
    public class ClaimsProfile : Profile
    {
        public ClaimsProfile()
        {
            CreateMap<Claim, RoleClaimsViewModel>().ReverseMap();
        }
    }
}