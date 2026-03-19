using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Sistema_de_Facturacion_Electronica.Dtos.Factura;
using Sistema_de_Facturacion_Electronica.Modelos;
namespace Sistema_de_Facturacion_Electronica.Mapas
{
    public static class MapaFactura
    {
        public static FacturaDTO ToFacturaDTO(this Factura NodoFactura)
        {
            return new FacturaDTO
            {
                Id = NodoFactura.Id,
                //FechaEmision = NodoFactura.FechaEmision,
                //FechaAutorizacion = NodoFactura.FechaAutorizacion,
                NumeroAutorizacion = NodoFactura.NumeroAutorizacion,
                NombreCliente = NodoFactura.NombreCliente,
                Subtotal = NodoFactura.Subtotal,
                TotalIPT = NodoFactura.TotalIPT,
                Descuento = NodoFactura.Descuento,
                TotalFinal = NodoFactura.TotalFinal,
                EstadoValidacion = NodoFactura.EstadoValidacion,
                Observaciones = NodoFactura.Observaciones,
                ClienteId = NodoFactura.IdCliente,
                idInfoTRB = NodoFactura.InfoTributariaId,
                idUsuario = NodoFactura.IdUsuario,
                //InfoDTO = NodoFactura.InfoTributaria.ToInfoDto() ?? null,
                Items = NodoFactura.Items.Select(m => m.ToItemDTO()).ToList(),
                Pagos = NodoFactura.Pagos.Select(m => m.ToPagoDTO()).ToList(),
            };
        }

        public static Factura ToFactura(this CrearFacturaDTO NodoFactura, string IdUsuario, int IdCliente)
        {
            return new Factura
            {
                NombreCliente = NodoFactura.NombreCliente,
                Descuento = NodoFactura.Descuento,
                InfoTributariaId = NodoFactura.idInfoTRB,
                IdUsuario = IdUsuario,
                IdCliente = IdCliente,
            };
        }

        public static factura ToFacturaXML(this Factura NodoFactura) 
        {
            return new factura
            {
                infoTributaria = {ambiente= NodoFactura.InfoTributaria.Ambiente.ToString(),tipoEmision=NodoFactura.InfoTributaria.TipoEmision.ToString(),
                razonSocial=NodoFactura.InfoTributaria.RazonSocial,nombreComercial=NodoFactura.InfoTributaria.NombreComercial,ruc = NodoFactura.InfoTributaria.RUC,
                claveAcceso=NodoFactura.InfoTributaria.ClaveUnica,codDoc=NodoFactura.InfoTributaria.CodTipoCompb,estab= NodoFactura.InfoTributaria.DirMatriz,
                ptoEmi=NodoFactura.InfoTributaria.PuntoEmision,secuencial=NodoFactura.InfoTributaria.NumeroSec,dirMatriz = NodoFactura.InfoTributaria.DirMatriz,agenteRetencion = "Retencion de Prueba", contribuyenteRimpe="EMPRENDEDOR"},

                infoFactura = {
                    fechaEmision = NodoFactura.FechaEmision.ToString("dd/MM/yyyy"),
                    dirEstablecimiento = NodoFactura.InfoTributaria.DirMatriz,
                    tipoIdentificacionComprador = "05",
                    razonSocialComprador = NodoFactura.NombreCliente,
                    identificacionComprador = NodoFactura.IdCliente.ToString(),
                    totalSinImpuestos = (decimal)NodoFactura.Subtotal,
                    totalDescuento = (decimal)NodoFactura.Descuento,
                    totalConImpuestos = new facturaInfoFacturaTotalImpuesto[] {
                        new facturaInfoFacturaTotalImpuesto {
                            codigo = "2",
                            codigoPorcentaje = "2",
                            baseImponible = 100,
                            valor = 15
                        },
                        new facturaInfoFacturaTotalImpuesto {
                            codigo = "3",
                            codigoPorcentaje = "3011",
                            baseImponible = 100,
                            valor = 10
                        }
                    },
                    importeTotal = (decimal)NodoFactura.TotalFinal,
                },

                detalles = new  facturaDetalle[] {
                    new facturaDetalle {
                        descripcion = "Producto 1",
                        cantidad = 2,
                        precioUnitario = 50,
                        descuento = 5,
                        precioTotalSinImpuesto = 95,
                        impuestos = new impuesto[] {
                            new impuesto {
                                codigo = "2",
                                codigoPorcentaje = "2",
                                tarifa = 15,
                                valor = 14
                            },
                            new impuesto {
                                codigo = "3",
                                codigoPorcentaje = "3011",
                                tarifa = 10,
                                valor = 9
                            }
                        }
                    },
                    new facturaDetalle {
                        descripcion = "Producto 2",
                        cantidad = 1,
                        precioUnitario = 100,
                        descuento = 10,
                        precioTotalSinImpuesto = 90,
                        impuestos = new impuesto[] {
                            new impuesto {
                                codigo = "2",
                                codigoPorcentaje = "2",
                                tarifa = 15,
                                valor = 13
                            },
                            new impuesto {
                                codigo = "3",
                                codigoPorcentaje = "3011",
                                tarifa = 10,
                                valor = 9
                            }
                        }
                    }
                },
                //reembolsos = new reembolsosReembolsoDetalle[0],
                tipoNegociable = { correo="wtobar@espol.edu.ec"},           
                maquinaFiscal = {marca="MarcaPrueba",modelo="ModeloPrueba",serie="prueba" },
                infoAdicional = new facturaCampoAdicional[] {
                    new facturaCampoAdicional { nombre = "Observaciones", Value = NodoFactura.Observaciones },
                    new facturaCampoAdicional { nombre = "EstadoValidacion", Value = NodoFactura.EstadoValidacion }
                },
                Signature = new SignatureType { },
                id = facturaID.comprobante,
                idSpecified = true,
                version = "1.0"
            };
        }
    }
}
