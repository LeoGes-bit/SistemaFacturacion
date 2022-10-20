using SistemaFacturacion.Application.Interfaces.Repositories.Facturacion;
using SistemaFacturacion.Infrastructure.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaFacturacion.Infrastructure.Data.Repositories.Facturacion
{
    public class UnitOfWork : IUnitOfWork//<T> : IUnitOfWork<T> where T : DbContext
    {
        // private readonly IAuthenticatedUserService _authenticatedUserService;
        //private readonly DbContext _dbContext;
        private bool disposed;
        private readonly FacturacionDbContext _dbContext;
        public UnitOfWork(FacturacionDbContext dbContext)//, IAuthenticatedUserService authenticatedUserService)
        {
            //if (dbContext==null)
            //{
            //    _dbContext = _dbContextRegistro ?? throw new ArgumentNullException(nameof(dbContext));
            //    return;
            //}

            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            // _authenticatedUserService = authenticatedUserService;
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task Rollback()
        {
            //todo
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
    }
}