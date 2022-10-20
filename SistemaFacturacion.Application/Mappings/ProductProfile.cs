
using SistemaFacturacion.Application.Features.Products.Queries.GetAllCached;
using SistemaFacturacion.Application.Features.Products.Queries.GetAllPaged;
using SistemaFacturacion.Application.Features.Products.Queries.GetById;
using SistemaFacturacion.Domain.Entities.Catalog;
using AutoMapper;
using SistemaFacturacion.Application.Features.Products.Commands.Create;

namespace SistemaFacturacion.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}