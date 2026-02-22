using System;

namespace Sistema_de_Facturacion_Electronica.ModelosSoporte
{
    public class FirmaDigital
    {
        public string EmisorCertificado { get; set; } = string.Empty;
        public string TitularCertificado { get; set; } = string.Empty;
        public string SerieCertificado { get; set; } = string.Empty;
        public string AlgoritmoFirma { get; set; } = string.Empty;
        public DateTime FechaEmisionCert { get; set; }
        public DateTime FechaExpiracionCert { get; set; }
        public string HuellaCertificado { get; set; } = string.Empty;
        public DateTime FechaFirma { get; set; } = DateTime.Now;
        public string EstadoFirma { get; set; } = string.Empty;
        public string XMLFirmado { get; set; } = string.Empty;
    }
}