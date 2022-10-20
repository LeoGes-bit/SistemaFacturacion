using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using SistemaFacturacion.Application.Interfaces.CacheRepositories.Maestro;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SistemaFacturacion.Application.Features.Maestro.Catalogos.Queries.GetAllCached
{
    public class GetAllCatalogosCachedQuery : IRequest<Result<List<GetAllCatalogosCachedResponse>>>
    {
        public string IdRol { get; set; }
        public GetAllCatalogosCachedQuery()
        {
        }
    }

    public class GetAllCatalogosCachedQueryHandler : IRequestHandler<GetAllCatalogosCachedQuery, Result<List<GetAllCatalogosCachedResponse>>>
    {
        private readonly ICatalogoCacheRepository _CatalogosCache;
        private readonly IMapper _mapper;
       


        public GetAllCatalogosCachedQueryHandler( ICatalogoCacheRepository CatalogosCache, IMapper mapper)
        {
            _CatalogosCache = CatalogosCache;
            _mapper = mapper;
            
        }

        public async Task<Result<List<GetAllCatalogosCachedResponse>>> Handle(GetAllCatalogosCachedQuery request, CancellationToken cancellationToken)
        {
            var CatalogosList = await _CatalogosCache.GetCachedListAsync(request.IdRol);
            var mappedCatalogos = _mapper.Map<List<GetAllCatalogosCachedResponse>>(CatalogosList);

            return Result<List<GetAllCatalogosCachedResponse>>.Success(mappedCatalogos);
        }
    }

}
