﻿using SistemaFacturacion.Domain.Entities.Maestro;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SistemaFacturacion.Application.Interfaces.Repositories.Maestro
{
    public interface ICatalogoRepository
    {
        IQueryable<Catalogo> Catalogos { get; }

        Task<List<Catalogo>> GetListAsync(string idRol);

        Task<Catalogo> GetByIdAsync(int id);

        Task<DetalleCatalogo> GetDetalleByIdAsync(int id, string secuencia);

        Task<List<DetalleCatalogo>> GetDetalleByIdCatalogoAsync(int id);

        Task<int> InsertAsync(Catalogo catalogo);

        Task UpdateAsync(Catalogo catalogo);

        Task DeleteAsync(Catalogo catalogo);
    }
}
