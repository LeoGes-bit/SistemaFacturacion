using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using SistemaFacturacion.Application.DTOs.Facturacion;
using SistemaFacturacion.Application.Interfaces.Repositories.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetAllCached
{
    public class GetDatosPersonasQuery : IRequest<Result<List<PersonaResponse>>>
    {
        public int Id { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public string Identificaion { get; set; }


        public GetDatosPersonasQuery()
        {
        }
        public class GetDatosPersonasQueryHandler : IRequestHandler<GetDatosPersonasQuery, Result<List<PersonaResponse>>>
        {
            private readonly IPersonaRepository _persona;
            private readonly IMapper _mapper;


            //Ejecuta el select
            public GetDatosPersonasQueryHandler(IPersonaRepository persona, IMapper mapper)
            {
                _persona = persona;
                _mapper = mapper;

            }

            public async Task<Result<List<PersonaResponse>>> Handle(GetDatosPersonasQuery request, CancellationToken cancellationToken)
            {
                var DonanteList = await _persona.GetListAsync( request.Identificaion, request.Apellidos, request.Nombres);
                var mappedPersona = _mapper.Map<List<PersonaResponse>>(DonanteList);

                return Result<List<PersonaResponse>>.Success(mappedPersona);
            }
        }
    }
}
