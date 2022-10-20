using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using SistemaFacturacion.Application.Interfaces.Repositories.Facturacion;
using SistemaFacturacion.Application.Interfaces.Repositories.Servicios;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;


namespace SistemaFacturacion.Application.Features.Facturacion.Personas.Commands.Update
{
    public class UpdatePersonaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public int TipoIdentifiacion { get; set; }
        public string Identificaion { get; set; }

        public string Direccion { get; set; }

        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }

        public string Email { get; set; }

        public int TipoCliente { get; set; }
        
        public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPersonaRepository _personaRepository;
            private readonly IMapper _mapper;

            public UpdatePersonaCommandHandler(IPersonaRepository personaRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _personaRepository = personaRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdatePersonaCommand command, CancellationToken cancellationToken)
            {
                //devuelve toda la fila
                var Persona = await _personaRepository.GetByIdAsync(command.Id);

                if (Persona == null)
                {
                    return Result<int>.Fail($"Persona no encontrada.");
                }
                else
                {
                   
                    Persona.Nombres = command.Nombres;
                    Persona.Apellidos = command.Apellidos;
                    Persona.TipoIdentifiacion = command.TipoIdentifiacion == 0 ? Persona.TipoIdentifiacion : command.TipoIdentifiacion;
                    Persona.Identificaion = command.Identificaion;
                    Persona.Direccion = command.Direccion;
                    Persona.TelefonoCelular = command.TelefonoCelular;
                    Persona.TelefonoConvencional = command.TelefonoConvencional;
                    Persona.Email = command.Email;
                    Persona.TipoCliente = command.TipoCliente == 0? Persona.TipoCliente : command.TipoCliente;
          
                   
                    await _personaRepository.UpdateAsync(Persona);


                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(Persona.Id);
                }
            }
        }


    }
}
