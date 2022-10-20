using SistemaFacturacion.Application.Interfaces.CacheRepositories;
using SistemaFacturacion.Application.Interfaces.Repositories;
using SistemaFacturacion.Infrastructure.CacheRepositories;
using SistemaFacturacion.Infrastructure.DbContexts;
using SistemaFacturacion.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaFacturacion.Application.Interfaces.CacheRepositories.Maestro;
using SistemaFacturacion.Application.Interfaces.Repositories.Maestro;
using SistemaFacturacion.Infrastructure.Data.Contexts;
//using SistemaFacturacion.Infrastructure.Data.Repositories.Maestro;

using System.Reflection;
using SistemaFacturacion.Application.Interfaces.Repositories.Identity;
using SistemaFacturacion.Infrastructure.Repositories.Identity;
using SistemaFacturacion.Application.Interfaces.Contexts;
using SistemaFacturacion.Infrastructure.Data.Repositories.Maestro;
using SistemaFacturacion.Infrastructure.Data.CacheRepositories.Maestro;
using SistemaFacturacion.Application.Interfaces.Repositories.Servicios;
using SistemaFacturacion.Infrastructure.Data.Repositories.Servicios;
//using SistemaFacturacion.Infrastructure.Data.CacheRepositories.Maestro;

namespace SistemaFacturacion.Infrastructure.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IFacturacionDbContext, FacturacionDbContext>();

        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories
             services.AddTransient(typeof(SistemaFacturacion.Application.Interfaces.Repositories.Identity.IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(SistemaFacturacion.Application.Interfaces.Repositories.Facturacion.IRepositoryAsync<>), typeof(SistemaFacturacion.Infrastructure.Data.Repositories.Facturacion.RepositoryAsync<>));

            services.AddTransient<Application.Interfaces.Repositories.Facturacion.IUnitOfWork, Repositories.Facturacion.UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCacheRepository, ProductCacheRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandCacheRepository, BrandCacheRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
          

            services.AddTransient<ICatalogoRepository, CatalogoRepository>();
            services.AddTransient<ICatalogoCacheRepository, CatalogoCacheRepository>();


            services.AddTransient<IPersonaRepository, PersonaRepository>();

            #endregion Repositories
        }
    }
}