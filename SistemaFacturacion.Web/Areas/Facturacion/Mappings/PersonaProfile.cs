using AutoMapper;
using SistemaFacturacion.Application.DTOs.Facturacion;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Commands.Create;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Commands.Update;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetAllCached;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetById;
using SistemaFacturacion.Domain.Entities.Facturacion;
using SistemaFacturacion.Web.Areas.Facturacion.Models;

namespace SistemaFacturacion.Web.Areas.Facturacion.Mappings
{
    public class PersonaProfile : Profile
    {

        public PersonaProfile()
        {
            CreateMap<CreatePersonaCommand, PersonaViewModel>().ReverseMap();           
            CreateMap<UpdatePersonaCommand, PersonaViewModel>().ReverseMap();
            CreateMap<GetAllPersonasResponse, PersonaViewModel>().ReverseMap();
            CreateMap<GetPersonasByIdResponse, PersonaViewModel>().ReverseMap();
            CreateMap<Persona, PersonaViewModel>().ReverseMap();
            CreateMap<PersonaResponse, PersonaResponseViewModel>().ReverseMap();
            CreateMap<PersonaResponse, PersonaViewModel>().ReverseMap();
        }
    }

}
