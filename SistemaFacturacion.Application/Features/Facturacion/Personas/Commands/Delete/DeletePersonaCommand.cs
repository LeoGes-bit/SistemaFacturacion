using AspNetCoreHero.Results;
using MediatR;
using SistemaFacturacion.Application.Interfaces.Repositories.Facturacion;
using SistemaFacturacion.Application.Interfaces.Repositories.Servicios;
using System.Threading;
using System.Threading.Tasks;


namespace SistemaFacturacion.Application.Features.Facturacion.Personas.Commands.Delete
{

    public class DeletePersonaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand, Result<int>>
        {
            private readonly IPersonaRepository _personaRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeletePersonaCommandHandler(IPersonaRepository personaRepository, IUnitOfWork unitOfWork)
            {
                _personaRepository = personaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeletePersonaCommand command, CancellationToken cancellationToken)
            {
                var Persona = await _personaRepository.GetByIdAsync(command.Id);
                await _personaRepository.DeleteAsync(Persona);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(Persona.Id);
            }
        }
    }

}
