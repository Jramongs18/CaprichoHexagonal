using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaprichoHexagonal.Core.Domain.Models
{
    public class Venta
    {
        public Guid venta_id { get; set; }
        public Guid cliente_id { get; set; }
        public int total_producto { get; set; }
        public Decimal monto_total { get; set; }
        public string contacto { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_venta { get; set; }
        public Guid transaccion_id { get; set; }
        public Guid comarca_id { get; set; }
        [ForeignKey("cliente_id")]
        public Cliente Cliente { get; set; }
        public List<DetalleVenta> DetalleVentas { get; set; }
       
    }
}
