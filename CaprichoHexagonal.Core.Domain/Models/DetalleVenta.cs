using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaprichoHexagonal.Core.Domain.Models
{
    public class DetalleVenta
    {
        public Decimal total { get; set; }
        public int cantidad { get; set; }
        public Guid venta_id { get; set; }
        public Guid producto_id { get; set; }
        [ForeignKey("venta_id")]
        public Venta Venta { get; set; }
        [ForeignKey("producto_id")]
        public Producto Producto { get; set; }
      
    }
}
