using SistemaFacturacion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.Domain.Entities.Facturacion
{
    public class Detalle : AuditableEntity
    {

        public decimal Cantidad { get; set; }

        public string Descripcion { get; set; }

        public int? ValorUnitario { get; set; }


        public int ValorTotal { get; set; }

        public decimal? SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal? Total { get; set; }

        public int IdPersona { get; set; }

        public Persona Personas { get; set; }

    }
}
