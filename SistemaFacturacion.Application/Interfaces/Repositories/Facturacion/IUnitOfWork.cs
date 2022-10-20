using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaFacturacion.Application.Interfaces.Repositories.Facturacion
{
    public interface IUnitOfWork<T> : IUnitOfWork where T : DbContext
    {
    }

    public interface IUnitOfWork
    {

        Task<int> Commit(CancellationToken cancellationToken);

        Task Rollback();
    }
}