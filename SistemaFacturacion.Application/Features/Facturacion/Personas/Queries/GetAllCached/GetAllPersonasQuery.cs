using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using SistemaFacturacion.Application.Interfaces.Repositories.Servicios;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetAllCached
{
    public class GetAllPersonasQuery : IRequest<Result<List<GetAllPersonasResponse>>>
    {

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public int TipoIdentifiacion { get; set; }
        public string Identificaion { get; set; }

        public string Direccion { get; set; }

        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }

        public string Email { get; set; }

        public int TipoCliente { get; set; }

        public GetAllPersonasQuery()
        {
        }
        public class GetAllPersonasQueryHandler : IRequestHandler<GetAllPersonasQuery, Result<List<GetAllPersonasResponse>>>
        {
            private readonly IPersonaRepository _persona;
            private readonly IMapper _mapper;


            //Ejecuta el select
            public GetAllPersonasQueryHandler(IPersonaRepository persona, IMapper mapper)
            {
                _persona = persona;
                _mapper = mapper;

            }

            public async Task<Result<List<GetAllPersonasResponse>>> Handle(GetAllPersonasQuery request, CancellationToken cancellationToken)
            {
                var PersonaList = await _persona.GetListAsync( request.Nombres, request.Apellidos, request.Identificaion);
                var mappedPersonas = _mapper.Map<List<GetAllPersonasResponse>>(PersonaList);

                return Result<List<GetAllPersonasResponse>>.Success(mappedPersonas);
            }
        }
    }
}
