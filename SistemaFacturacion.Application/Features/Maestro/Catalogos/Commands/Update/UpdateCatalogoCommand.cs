﻿using SistemaFacturacion.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using SistemaFacturacion.Application.Interfaces.Repositories.Maestro;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SistemaFacturacion.Application.Interfaces.Repositories.Facturacion;

namespace SistemaFacturacion.Application.Features.Maestro.Catalogos.Commands.Update
{
    public class UpdateCatalogoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public ICollection<DetalleCatalogoResponse> DetalleCatalogos { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateCatalogoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICatalogoRepository _CatalogoRepository;

            public UpdateProductCommandHandler(ICatalogoRepository CatalogoRepository, IUnitOfWork unitOfWork)
            {
                _CatalogoRepository = CatalogoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateCatalogoCommand command, CancellationToken cancellationToken)
            {
                var Catalogo = await _CatalogoRepository.GetByIdAsync(command.Id);

                if (Catalogo == null)
                {
                    return Result<int>.Fail($"Catalogo no encontrado.");
                }
                else
                {
                    Catalogo.Nombre = command.Nombre;
                    Catalogo.Estado = command.Estado;


                    await _CatalogoRepository.UpdateAsync(Catalogo);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(Catalogo.Id);
                }
            }
        }
    }
}
