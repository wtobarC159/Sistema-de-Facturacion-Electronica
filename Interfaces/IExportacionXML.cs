using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Interfaces
{
    public interface IExportacionXML
    {
        string? ExportacionXML(Factura NodoFactura);
    }
}
