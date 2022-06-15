using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaprichoHexagonal.Core.Domain.Models
{
    public class Producto
    {
        public Guid producto_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Decimal precio { get; set; }
        public int stock { get; set; }
        public string ruta_imagen { get; set; }
        public string nombre_imagen { get; set; }
        public Boolean activo { get; set; }
        public DateTime fecha_registro { get; set; }
        public Guid marca_id { get; set; }
        public Guid categoria_id { get; set; }
        [ForeignKey("marca_id")]
        public Marca Marca { get; set; }
        [ForeignKey("categoria_id")]
        public Categoria Categoria { get; set; }
        public List<DetalleVenta> DetalleVentas { get; set; }
        public List<Carrito> Carritos { get; set; }
    }
}
