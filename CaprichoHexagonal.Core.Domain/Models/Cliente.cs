using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaprichoHexagonal.Core.Domain.Models
{
    public class Cliente
    {
        public Guid cliente_id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public DateTime fecha_registro { get; set; }
        public Boolean reestablecer { get; set; }
        public List<Venta> Ventas { get; set; }
        public List<Carrito> Carritos { get; set; }

    }
}
