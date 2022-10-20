using AutoMapper;
using SistemaFacturacion.Application.Features.Maestro.Catalogos;
using SistemaFacturacion.Application.Features.Maestro.Catalogos.Commands.Create;
using SistemaFacturacion.Application.Features.Maestro.Catalogos.Commands.Update;
using SistemaFacturacion.Application.Features.Maestro.Catalogos.Queries.GetAllCached;
using SistemaFacturacion.Application.Features.Maestro.Catalogos.Queries.GetById;
using SistemaFacturacion.Domain.Entities.Maestro;
using SistemaFacturacion.Web.Areas.Maestro.Models;

namespace SistemaFacturacion.Web.Areas.Maestro.Mappings
{
    internal class CatalogoProfile : Profile
    {
        public CatalogoProfile()
        {
            CreateMap<GetAllCatalogosCachedResponse, CatalogoViewModel>().ReverseMap();
            CreateMap<GetCatalogoByIdResponse, CatalogoViewModel>().ReverseMap();
            CreateMap<CreateCatalogoCommand, CatalogoViewModel>().ReverseMap();
            CreateMap<UpdateCatalogoCommand, CatalogoViewModel>().ReverseMap();
            CreateMap<DetalleCatalogoViewModel, DetalleCatalogo>().ReverseMap();
            CreateMap<DetalleCatalogoViewModel, DetalleCatalogoResponse>().ReverseMap();


        }
    }
}
