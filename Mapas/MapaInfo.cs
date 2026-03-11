using Sistema_de_Facturacion_Electronica.Dtos.InfoTributDTO;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Mapas
{
    public static class MapaInfo
    {
        public static InfoTributariaDTO ToInfoDto (this InfoTributaria NodoInfo)
        {
            return new InfoTributariaDTO 
            {
                Ambiente = NodoInfo.Ambiente,
                TipoEmision = NodoInfo.TipoEmision,
                RazonSocial = NodoInfo.RazonSocial,
                NombreComercial = NodoInfo.NombreComercial,
                RUC = NodoInfo.RUC,
                ClaveUnica = NodoInfo.ClaveUnica,
                CodTipoCompb = NodoInfo.CodTipoCompb,
                PuntoEmision = NodoInfo.PuntoEmision,
                NumeroSec = NodoInfo.NumeroSec,
                DirMatriz = NodoInfo.DirMatriz,
            };
        }
    }
}
