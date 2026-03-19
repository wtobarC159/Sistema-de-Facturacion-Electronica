using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Mapas;
using Sistema_de_Facturacion_Electronica.Modelos;
using System.Text;
using System.Xml.Serialization;

namespace Sistema_de_Facturacion_Electronica.Servicios
{
    public class ExportacionXML : IExportacionXML
    {
        string? IExportacionXML.ExportacionXML(Factura NodoFactura)
        {
            var facturaXsd = NodoFactura.ToFacturaXML();

            try
            {
                var serializer = new XmlSerializer(typeof(factura));
                using var ms = new MemoryStream();
                serializer.Serialize(ms, facturaXsd);
                ms.Position = 0;
                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
