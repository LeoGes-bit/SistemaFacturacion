using SistemaFacturacion.Application.Features.Brands.Commands.Create;
using SistemaFacturacion.Application.Features.Brands.Queries.GetAllCached;
using SistemaFacturacion.Application.Features.Brands.Queries.GetById;
using SistemaFacturacion.Domain.Entities.Catalog;
using AutoMapper;

namespace SistemaFacturacion.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}