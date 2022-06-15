using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaprichoHexagonal.Core.Domain.Models
{
    public class Municipio
    {
        public Guid municipio_id { get; set; }
        public string descripcion { get; set; }
        public Guid departamento_id { get; set; }
        [ForeignKey("departamento_id")]
        public Departamento Departamento { get; set; }
        public List<Comarca> Comarcas { get; set; } 
    }
}
