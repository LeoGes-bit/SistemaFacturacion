using SistemaFacturacion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.Domain.Entities.Facturacion
{
    public class Factura : AuditableEntity
    {

        public DateTime FechaEmision { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public int Secuencial { get; set; }
        public int PuntoVenta { get; set; }
        public int PuntoEmision { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public int IdPersona { get; set; }

        public Persona Personas { get; set; }

    }
}
