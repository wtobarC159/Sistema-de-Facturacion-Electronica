namespace Sistema_de_Facturacion_Electronica.Helpers
{
    public class QueryObject
    {
        public string? Referencia { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool Descendente { get; set; } = false;
        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 20;
    }
}
