
using SistemaFacturacion.Application.Features.Products.Queries.GetAllCached;
using SistemaFacturacion.Application.Features.Products.Queries.GetById;
using SistemaFacturacion.Web.Areas.Catalog.Models;
using AutoMapper;
using SistemaFacturacion.Application.Features.Products.Commands.Create;
using SistemaFacturacion.Application.Features.Products.Commands.Update;

namespace SistemaFacturacion.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}