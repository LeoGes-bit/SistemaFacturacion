using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion.Web.Areas.Facturacion.Models
{
    public class PersonaViewModel
    {

        public int Vienede { get; set; }
        public int Id { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        [Display(Name = "Tipo Id.")]
        public int TipoIdentifiacion { get; set; }

        [Display(Name = "Identificación")]
        public string Identificaion { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono Convencional")]
        public string TelefonoConvencional { get; set; }

        [Display(Name = "Teléfono Celular")]
        public string TelefonoCelular { get; set; }

        public string Email { get; set; }

        public int TipoCliente { get; set; }

        public int TipoPantalla { get; set; }
        public SelectList TipoIdentifiacionList { get; set; }

        public SelectList TipoClienteList { get; set; }
    }
    public class PersonaResponseViewModel
    {
        public string Id { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public string TipoIdentifiacion { get; set; }
        public string Identificaion { get; set; }

        public string TipoCliente { get; set; }
          
      
    }

    public class PersonaFiltroViewModel
    {
        public string Identificacion { get; set; }
     
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        //public int TipoPantalla { get; set; }

    }
}
