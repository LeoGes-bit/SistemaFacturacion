using SistemaFacturacion.Application.Features.Brands.Commands.Create;
using SistemaFacturacion.Application.Features.Brands.Commands.Update;
using SistemaFacturacion.Application.Features.Brands.Queries.GetAllCached;
using SistemaFacturacion.Application.Features.Brands.Queries.GetById;
using SistemaFacturacion.Web.Areas.Catalog.Models;
using AutoMapper;

namespace SistemaFacturacion.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}