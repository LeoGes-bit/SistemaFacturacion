using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.Domain.Entities
{
    public class GenericEntity
    {
        [NotMapped]
        public bool Include { get; set; }
    }
}
