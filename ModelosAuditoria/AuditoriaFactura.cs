namespace Sistema_de_Facturacion_Electronica.ModelosAuditoria
{
    public class AuditoriaFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string UsuarioApp { get; set; } = string.Empty;
        public DateTime FechaAccion { get; set; }
        public string ValorAnterior { get; set; } = string.Empty;
        public string ValorNuevo { get; set; } = string.Empty;
    }
}
