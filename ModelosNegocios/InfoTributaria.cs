using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    public class InfoTributaria
    {
        public int Id { get; set; }
        public int Ambiente { get; set; }
        public int TipoEmision { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public string NombreComercial { get; set; } = string.Empty;
        public string RUC { get; set; } = string.Empty;
        public string ClaveUnica { get; set; } = string.Empty;
        public string CodTipoCompb { get; set; } = string.Empty;
        public string PuntoEmision { get; set; } = string.Empty;
        public string NumeroSec { get; set; } = string.Empty;
        public string DirMatriz { get; set; } = string.Empty;
    }
}
