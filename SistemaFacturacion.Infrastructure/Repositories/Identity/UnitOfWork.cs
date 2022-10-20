using SistemaFacturacion.Application.Interfaces.Repositories;

using SistemaFacturacion.Infrastructure.DbContexts;
using SistemaFacturacion.Application.Interfaces.Repositories.Identity;
using SistemaFacturacion.Application.Interfaces.Shared;
using SistemaFacturacion.Infrastructure.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaFacturacion.Infrastructure.Repositories.Identity
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly FacturacionDbContext _dbContext;
        private bool disposed;

        public UnitOfWork(FacturacionDbContext dbContext, IAuthenticatedUserService authenticatedUserService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _authenticatedUserService = authenticatedUserService;
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