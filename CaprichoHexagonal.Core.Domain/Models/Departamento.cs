using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaprichoHexagonal.Core.Domain.Models
{
    public class Departamento
    {
        public Guid departamento_id { get; set; }
        public string descripcion { get; set; }
        public List<Municipio> Municipios { get; set; }
    }
}
