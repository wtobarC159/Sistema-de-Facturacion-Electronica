using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    [Table("Productos")]
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public string ImpuestosPRD { get; set; } = string.Empty;
        public List<Impuesto> ImpAplicables { get; set; } = new List<Impuesto>();
        public List<Item> ItemProducto { get; set; } = new List<Item>();
    }
}
