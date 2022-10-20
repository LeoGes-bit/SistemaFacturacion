using AutoMapper;
using SistemaFacturacion.Application.Features.Maestro.Catalogos;
using SistemaFacturacion.Application.Features.Maestro.Catalogos.Commands.Create;
using SistemaFacturacion.Application.Features.Maestro.Catalogos.Commands.Update;
using SistemaFacturacion.Application.Features.Maestro.Catalogos.Queries.GetAllCached;
using SistemaFacturacion.Application.Features.Maestro.Catalogos.Queries.GetById;
using SistemaFacturacion.Domain.Entities.Maestro;


namespace SistemaFacturacion.Application.Mappings.Maestro
{
    internal class CatalogoProfile : Profile
    {
        public CatalogoProfile()
        {
            CreateMap<CreateCatalogoCommand, Catalogo>().ReverseMap();
            CreateMap<GetCatalogoByIdResponse, Catalogo>().ReverseMap();
            CreateMap<GetAllCatalogosCachedResponse, Catalogo>().ReverseMap();
            CreateMap<UpdateCatalogoCommand, Catalogo>().ReverseMap();

            CreateMap<GetListByIdDetalleResponse, DetalleCatalogo>().ReverseMap();
            CreateMap<DetalleCatalogoResponse, DetalleCatalogo>().ReverseMap();

        }
    }
}
