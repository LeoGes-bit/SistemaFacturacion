using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SistemaFacturacion.Application.DTOs.Facturacion;
using SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetAllCached;
using SistemaFacturacion.Application.Interfaces.Repositories.Facturacion;
using SistemaFacturacion.Application.Interfaces.Repositories.Servicios;
using SistemaFacturacion.Domain.Entities.Facturacion;
using SistemaFacturacion.Domain.Entities.Maestro;
using SistemaFacturacion.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SistemaFacturacion.Infrastructure.Data.Repositories.Servicios
{



    public class PersonaRepository : IPersonaRepository

    {
        private readonly FacturacionDbContext _db;
        private readonly IRepositoryAsync<Persona> _repository;
        private readonly IRepositoryAsync<DetalleCatalogo> _repositoryDetalle;

        private readonly IDistributedCache _distributedCache;

        public PersonaRepository(IRepositoryAsync<DetalleCatalogo> repositoryDetalle, FacturacionDbContext db, IRepositoryAsync<Persona> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
            _db = db;
            _repositoryDetalle = repositoryDetalle;


        }

        public IQueryable<Persona> personas => _repository.Entities;


        public async Task DeleteAsync(Persona persona)
        {
            await _repository.DeleteAsync(persona);
        }


        public async Task<Persona> GetPersonaAsync(int idPersona)
        {
            return await _repository.Entities.Where(x => x.Id == idPersona).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(Persona persona)
        {
            await _repository.AddAsync(persona);
            return persona.Id;
        }

        public async Task UpdateAsync(Persona persona)
        {
            await _repository.UpdateAsync(persona);
        }

        public async Task<Persona> GetByIdAsync(int idPersona)
        {
            return await _repository.Entities.Where(x => x.Id == idPersona).FirstOrDefaultAsync();
        }

        public async Task<List<PersonaResponse>> GetListAsync(string identificacion, string nombres, string apellidos)
        {
            var resultado1 = _repository.Entities.Where(x =>  x.Identificaion == identificacion && ((x.Apellidos).Contains(apellidos) || apellidos == "") && ((x.Nombres).Contains(nombres) || nombres == ""))
                                        .Select(a => new PersonaResponse
                                        {
                                            Id =a.Id,
                                            Nombres = a.Nombres,
                                            Apellidos = a.Apellidos,
                                            Identificaion = a.Identificaion,
                                            TipoCliente = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 2 && c.Secuencia == a.TipoCliente.ToString()).FirstOrDefault().Nombre,
                                            TipoIdentifiacion = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 1 && c.Secuencia == a.TipoIdentifiacion.ToString()).FirstOrDefault().Nombre,
                                        }).ToListAsync();

            return await resultado1;
        }
    }
          
}
