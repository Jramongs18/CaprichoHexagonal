using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaprichoHexagonal.Core.Domain.Models
{
    public class Carrito
    {
        public Guid cliente_id { get; set; }
        public Guid producto_id { get; set; }
        public int cantidad { get; set; }
        [ForeignKey("cliente_id")]
        public Cliente Cliente { get; set; }
        [ForeignKey("producto_id")]
        public Producto Producto { get; set; }
    }
}
