using AspNetCoreHero.EntityFrameworkCore.AuditTrail;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.Application.Interfaces.Contexts;
using SistemaFacturacion.Application.Interfaces.Shared;
using SistemaFacturacion.Domain.Contracts;
using SistemaFacturacion.Domain.Entities.Facturacion;
using SistemaFacturacion.Domain.Entities.Maestro;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaFacturacion.Infrastructure.Data.Contexts
{
    public class FacturacionDbContext : AuditableContext, IFacturacionDbContext //AuditableContext
    {

        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;
        public FacturacionDbContext(DbContextOptions<FacturacionDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser)
            : base(options)
        {
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }



        public IDbConnection Connection => Database.GetDbConnection();
        public bool HasChanges => ChangeTracker.HasChanges();

        

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.Username;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.Username;
                        break;
                }
            }
            if (_authenticatedUser.Username == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                    
                return await base.SaveChangesAsync(_authenticatedUser.Username);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Catalogo>()
           .ToTable("Catalogos", "adm");
            builder.Entity<DetalleCatalogo>()
           .ToTable("DetalleCatalogos", "adm");

            builder.Entity<Persona>()
               .ToTable("Personas", "facturacion");
            builder.Entity<Factura>()
               .ToTable("Facturas", "facturacion");
            builder.Entity<Detalle>()
               .ToTable("Detalles", "facturacion");
            builder.Entity<Empresa>()
               .ToTable("Empresas", "facturacion");
            builder.Entity<PuntoVenta>()
               .ToTable("PuntoVentas", "facturacion");

        }
    }
}
