using SistemaFacturacion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.Domain.Entities.Facturacion
{
    public class Empresa : AuditableEntity
    {
        public int TipoIdentifiacion { get; set; }

        public string Identificaion { get; set; }
        public string NombreRazonSocial { get; set; }
       
        public string Direccion { get; set; }

        public string Telefono{ get; set; }
        public string Email { get; set; }

        [ForeignKey("IdEmpresa")]
        public ICollection<PuntoVenta> PuntoVentas { get; set; }



    }
}
