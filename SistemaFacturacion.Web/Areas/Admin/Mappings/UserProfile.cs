using SistemaFacturacion.Infrastructure.Identity.Models;
using SistemaFacturacion.Web.Areas.Admin.Models;
using AutoMapper;

namespace SistemaFacturacion.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}