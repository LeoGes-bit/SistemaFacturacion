using AutoMapper;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Commands.Create;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Commands.Update;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetAllCached;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetById;
using SistemaFacturacion.Domain.Entities.Facturacion;

namespace SistemaFacturacion.Application.Mappings.Facturacion
{
    public class PersonaProfile : Profile
    {

        public PersonaProfile()
        {
            CreateMap<CreatePersonaCommand, Persona>().ReverseMap();
            CreateMap<UpdatePersonaCommand, Persona>().ReverseMap();
            CreateMap<GetAllPersonasResponse, Persona>().ReverseMap();
            CreateMap<GetPersonasByIdResponse, Persona>().ReverseMap();
            


        }
    }

}
