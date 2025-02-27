﻿using SistemaFacturacion.Domain.Entities.Maestro;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SistemaFacturacion.Application.Interfaces.CacheRepositories.Maestro
{
    public interface ICatalogoCacheRepository
    {
        Task<List<Catalogo>> GetCachedListAsync(string idRol);

        Task<Catalogo> GetByIdAsync(int id);

        Task<ICollection<DetalleCatalogo>> GetDetalleByIdAsync(int id, string secuencia);

        Task<List<DetalleCatalogo>> GetDetalleByIdCatalogoAsync(int id);
    }
}
