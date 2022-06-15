using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaprichoHexagonal.Core.Domain.Models
{
    public class Comarca
    {
        public Guid comarca_id { get; set; }
        public string descripcion { get; set; }
        public Guid municipio_id { get; set; }
        [ForeignKey("municipio_id")]
        public Municipio municipio { get; set; }
    }
}
