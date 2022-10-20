using SistemaFacturacion.Application.DTOs.Facturacion;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetAllCached;
using SistemaFacturacion.Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Application.Interfaces.Repositories.Servicios
{
    public interface IPersonaRepository
    {
        IQueryable<Persona> personas { get; }

        //  Task<List<GetAllPersonasResponse>> GetListAsync(string nombres, string apellidos, string identificacion);

        Task<List<PersonaResponse>> GetListAsync(string nombres, string apellidos, string identificacion);
        Task<int> InsertAsync(Persona persona);

        Task UpdateAsync(Persona persona);
        Task DeleteAsync(Persona persona);
        Task<Persona> GetPersonaAsync(int idPersona);
        Task<Persona> GetByIdAsync(int idPersona);

        //Task UpdateAsyncXEstado(int idDonante, int estadoDonante);


        //Task<List<ReporteDonantesResponse>> GetReporteDonantesAsync(DateTime fechaDesde, DateTime fechaHasta, int tipoDonante, int formaPago, int estadoDonante, int estadoPago);
    }
}
