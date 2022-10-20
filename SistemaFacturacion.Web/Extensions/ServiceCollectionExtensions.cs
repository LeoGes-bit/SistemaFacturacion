using SistemaFacturacion.Application.DTOs.Settings;
using SistemaFacturacion.Application.Interfaces.Shared;
using SistemaFacturacion.Infrastructure.DbContexts;
using SistemaFacturacion.Infrastructure.Identity.Models;
using SistemaFacturacion.Infrastructure.Shared.Services;
using SistemaFacturacion.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaFacturacion.Infrastructure.Data.Contexts;
using System.Collections.Generic;
using System.Globalization;
using SistemaFacturacion.Web;

namespace SistemaFacturacion.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMultiLingualSupport(this IServiceCollection services)
        {
            #region Registering ResourcesPath

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            #endregion Registering ResourcesPath

            services.AddMvc()
               .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
               .AddDataAnnotationsLocalization(options =>
               {
                   options.DataAnnotationLocalizerProvider = (type, factory) =>
                       factory.Create(typeof(SharedResource));
               });
            services.AddRouting(o => o.LowercaseUrls = true);
            services.AddHttpContextAccessor();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo> {
                    new CultureInfo("en"),
                    new CultureInfo("ar"),
                    new CultureInfo("fr"),
                    new CultureInfo("fa"),
                    new CultureInfo("pt-BR"),
                };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddPersistenceContexts(configuration);
            services.AddAuthenticationScheme(configuration);
        }

        private static void AddAuthenticationScheme(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(o =>
            {
                //Add Authentication to all Controllers by default.
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        private static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseInMemoryDatabase("IdentityDb"));
                services.AddDbContext<FacturacionDbContext>(options =>
                    options.UseInMemoryDatabase("FacturacionDb"));
            }
            else
            {
                services.AddDbContext<IdentityContext>(options => options.UseNpgsql(configuration.GetConnectionString("IdentityConnection")));
                services.AddDbContext<FacturacionDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("FacturacionConnection"),
                sqlServerOptions => sqlServerOptions.CommandTimeout(60)); options.EnableSensitiveDataLogging(true);
                });
            }
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<IdentityContext>().AddDefaultUI().AddDefaultTokenProviders();
        }

        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.Configure<CacheSettings>(configuration.GetSection("CacheSettings"));
            services.AddTransient<IDateTimeService, SystemDateTimeService>();
            services.AddTransient<IMailService, SMTPMailService>();
            services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();
        }
    }
}