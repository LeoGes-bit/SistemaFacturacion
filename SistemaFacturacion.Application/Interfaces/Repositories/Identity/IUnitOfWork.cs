using System;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaFacturacion.Application.Interfaces.Repositories.Identity
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit(CancellationToken cancellationToken);

        Task Rollback();
    }
}