using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.Application.DTOs.Facturacion
{
    public class PersonaResponse
    {
        public int Id { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public string TipoIdentifiacion { get; set; }
        public string Identificaion { get; set; }

        public string TipoCliente { get; set; }
    }
}
