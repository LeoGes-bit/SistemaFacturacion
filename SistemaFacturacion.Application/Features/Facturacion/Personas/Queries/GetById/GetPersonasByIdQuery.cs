using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using SistemaFacturacion.Application.Interfaces.Repositories.Servicios;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetById
{
    public class GetPersonasByIdQuery : IRequest<Result<GetPersonasByIdResponse>>
    {
        public int Id { get; set; }

        public class GetPersonasByIdQueryHandler : IRequestHandler<GetPersonasByIdQuery, Result<GetPersonasByIdResponse>>
        {
            private readonly IPersonaRepository _personaRepository;



            private readonly IMapper _mapper;

            public GetPersonasByIdQueryHandler(IPersonaRepository personaRepository, IMapper mapper)
            {
                _personaRepository = personaRepository;

                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            //Devuelve todos la información de las entidades. 
            public async Task<Result<GetPersonasByIdResponse>> Handle(GetPersonasByIdQuery query, CancellationToken cancellationToken)
            {
                var persona = await _personaRepository.GetByIdAsync(query.Id);


                var mappedPersonas = _mapper.Map<GetPersonasByIdResponse>(persona);

                return Result<GetPersonasByIdResponse>.Success(mappedPersonas);
            }
        }
    }
}
