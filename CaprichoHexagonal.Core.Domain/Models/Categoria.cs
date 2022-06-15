using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaprichoHexagonal.Core.Domain.Models
{
    public class Categoria
    {
        public Guid categoria_id { get; set; }
        public string descripcion { get; set; }
        public Boolean activo { get; set; }
        public DateTime fecha_registro { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
