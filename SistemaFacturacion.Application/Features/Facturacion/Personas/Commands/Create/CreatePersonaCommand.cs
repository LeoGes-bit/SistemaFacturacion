using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using SistemaFacturacion.Application.Interfaces.Repositories.Facturacion;
using SistemaFacturacion.Application.Interfaces.Repositories.Servicios;
using SistemaFacturacion.Domain.Entities.Facturacion;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;


namespace SistemaFacturacion.Application.Features.Facturacion.Personas.Commands.Create
{
    public partial class CreatePersonaCommand : IRequest<Result<int>>
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
    }
    public class CreateDonanteCommandHandler : IRequestHandler<CreatePersonaCommand, Result<int>>
    {
        private readonly IPersonaRepository _personaRepository;


        private readonly IMapper _mapper;//coge los campos de la interfaz con la bbdd hace un mapeo

        private IUnitOfWork _unitOfWork { get; set; }// hace la transaccionabilidad crea la cabecera y luego detalle



        public CreateDonanteCommandHandler(IPersonaRepository personaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personaRepository = personaRepository;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //ejecuta directamene desde a interfaz el controaldor
        public async Task<Result<int>> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
        {
            var persona = _mapper.Map<Persona>(request);//mapea
            await _personaRepository.InsertAsync(persona);//INsertar a la BBDD


            await _unitOfWork.Commit(cancellationToken);//commit
            return Result<int>.Success(persona.Id);//devuelve le id existoso de la persona
        }
    }

}
