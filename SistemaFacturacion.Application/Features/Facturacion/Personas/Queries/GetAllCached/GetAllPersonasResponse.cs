using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion.Application.Features.Facturacion.Personas.Queries.GetAllCached
{
    public class GetAllPersonasResponse
    {
        public int Id { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public int TipoIdentifiacion { get; set; }
        public string Identificaion { get; set; }

        public string Direccion { get; set; }

        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }

        public string Email { get; set; }

        public int TipoCliente { get; set; }
    }
}
