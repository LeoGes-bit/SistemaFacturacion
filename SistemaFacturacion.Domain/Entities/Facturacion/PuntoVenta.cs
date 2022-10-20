using SistemaFacturacion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.Domain.Entities.Facturacion
{
    public class PuntoVenta : AuditableEntity
    {
        public int Secuencial { get; set; }
        public int PuntoDeVenta { get; set; }
        public int PuntoEmision {get; set;}
        public int IdEmpesa { get; set; }

        public Empresa Empresas { get; set; }
    }
}
