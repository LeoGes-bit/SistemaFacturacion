using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using SistemaFacturacion.Application.Interfaces.Repositories.Facturacion;
using SistemaFacturacion.Application.Interfaces.Repositories.Maestro;
using SistemaFacturacion.Domain.Entities.Maestro;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SistemaFacturacion.Application.Features.Maestro.Catalogos.Commands.Create
{
    public class CreateCatalogoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public ICollection<DetalleCatalogoResponse> DetalleCatalogos { get; set; }
    }

    public class CreateCatalogoCommandHandler : IRequestHandler<CreateCatalogoCommand, Result<int>>
    {
        private readonly ICatalogoRepository _EstructuraRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateCatalogoCommandHandler(ICatalogoRepository EstructuraRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _EstructuraRepository = EstructuraRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCatalogoCommand request, CancellationToken cancellationToken)
        {
            var estructura = _mapper.Map<Catalogo>(request);
            await _EstructuraRepository.InsertAsync(estructura);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(estructura.Id);
        }
    }
}
