using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    [Table("Impuestos")]
    public class Impuesto
    {
        public int Id { get; set; }
        public string TipoImpuesto { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Porcentaje { get; set; }
        public string Vigencia { get; set; }= string.Empty;

        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
