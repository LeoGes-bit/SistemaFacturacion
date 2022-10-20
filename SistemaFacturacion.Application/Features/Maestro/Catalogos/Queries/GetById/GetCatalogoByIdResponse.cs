using SistemaFacturacion.Domain.Entities.Maestro;
using System.Collections.Generic;


namespace SistemaFacturacion.Application.Features.Maestro.Catalogos.Queries.GetById
{
    public class GetCatalogoByIdResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public ICollection<DetalleCatalogo> DetalleCatalogos { get; set; }
    }
}
