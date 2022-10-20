using SistemaFacturacion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.Domain.Entities.Facturacion
{
    public class Persona : AuditableEntity
    {
        public string Nombres { get; set; }
        
        public string Apellidos { get; set; }
       
        public int TipoIdentifiacion { get; set; }
        public string Identificaion { get; set; }
      
        public string Direccion { get; set; }

        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }

        public string Email { get; set; }

        public int TipoCliente { get; set; }


        [ForeignKey("IdPersona")]
        public ICollection<Detalle> Personas { get; set; }


        [ForeignKey("IdPersona")]
        public ICollection<Factura> Facturas { get; set; }

    }
}
