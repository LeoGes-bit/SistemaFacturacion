using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.Domain.Entities.Identity;

namespace SistemaFacturacion.Application.Interfaces.CacheRepositories.Identity
{
    public interface IIdentityCacheRepository
    {
        Task<List<UsuariosActiveDirectory>> GetCachedListAsync();

        Task<UsuariosActiveDirectory> GetByIdAsync(string usuarioId);
    }
}
