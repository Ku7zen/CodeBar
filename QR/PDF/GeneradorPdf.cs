using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace QR.PDF
{
    public class HeaderFooteReporte
    {
        internal String observaciones;
         

    }
    public class GeneradorPdf
    {  /* //Variables para el contenido de el documento 
        String ordenPedido = "";
        String tituloNota = string.Empty;
        String tipoPago = string.Empty;
        String fecha = string.Empty;
        String nombreCliente = string.Empty;
        String direccion = string.Empty;
        String rfc = string.Empty;
     
        public static string generaArchivoRemision(List<VW_VENTAS_CLIENTE> notaRemision, List<VW_VENTAS_CLIENTE_CANCELADAS> notaCancelada, List<VW_VENT_NOTAS_ENTREGA> notasEntrega, List<VW_VENT_NOTAS_CREDITO> notaCredito, String nombreArchivo, String rutaArchivo)
        {
            try
            {
                eliminaArchivosPdf(rutaArchivo);
            }
            catch
            {
            }
            String observaciones = "";
            //Prueba del documento
            FileStream file = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            Document documento = new Document(PageSize.LETTER.Rotate(), 390, -30, 30, 10); //Se crea el documento pdf
            Font fuenteNegrita = new Font(FontFactory.GetFont("Arial Black", 13, Font.BOLD, BaseColor.BLACK));
            var v_fuenteNumeroDocto = FontFactory.GetFont("Helvetica", 12, Font.BOLD);
            PdfWriter archivoPdf = PdfWriter.GetInstance(documento, file);
            //creando el header
            HeaderFooteReporte ev = new HeaderFooteReporte();
            String ordenPedido = "";
            String tituloNota = string.Empty;
            String tipoPago = string.Empty;
            String fecha = string.Empty;
            String nombreCliente = string.Empty;
            String direccion = string.Empty;
            String rfc = string.Empty;
            int numeroDocumento = 0;

            if (notaRemision is null)
            {
                if (notaCredito is null)
                {
                    nombreCliente = notaCancelada[0].Nombre;
                }
                else
                {
                    nombreCliente = notasEntrega[0].Nombre;
                }
            }
            else
            {
                nombreCliente = notaRemision[0].Nombre;
            } 

            int d = 1 == 0 ? 2 : 3;

            nombreCliente = notaRemision != null ? notaRemision[0].Nombre : notaCredito != null ?
                                                 notaCredito[0].Nombre : notaCancelada != null ?
                                                 notaCancelada[0].Nombre : notasEntrega[0].Nombre;

            direccion = notaRemision != null ? notaRemision[0].Direccion : notaCredito != null ? 
                                                (notaCredito[0].Direccion != null 
                                                ? notaCredito[0].Direccion.ToUpper().Trim() : "")
                                                : notasEntrega != null ? (notasEntrega[0].Direccion != null 
                                                ? notasEntrega[0].Direccion.ToUpper().Trim() : string.Empty)
                                                : notaCancelada != null ? (notaCancelada[0].Direccion != null
                                                ? notaCancelada[0].Direccion.ToUpper().Trim() : string.Empty) : string.Empty;

            rfc = notaRemision != null ? notaRemision[0].Rfc : notaCredito != null ? 
                                                notaCredito[0].Rfc : notaCancelada != null ? 
                                                notaCancelada[0].Rfc : notasEntrega[0].Rfc;

            ev.total = (notaRemision != null ? notaRemision[0].TotalVenta.ToString("0.00") : notaCredito != null 
                                                ? notaCredito[0].Total.Value.ToString("0.00") : notaCancelada != null
                                                ? notaCancelada[0].TotalVenta.ToString("0.00") : notasEntrega[0].Total.Value.ToString("0.00"));
            
            if (notaRemision != null || notaCancelada != null)
            {
                numeroDocumento = notaRemision != null ? notaRemision[0].IdNotaVenta.Value : notaCancelada[0].IdNotaVenta.Value;
                tituloNota = "Nota de Venta: " + (notaRemision != null ? notaRemision[0].IdNotaVenta.Value : notaCancelada[0].IdNotaVenta.Value);
                tipoPago = "Tipo de Pago: " + (notaRemision != null ? notaRemision[0].TipoPago : notaCancelada[0].TipoPago);
                fecha = notaRemision != null ? notaRemision[0].FechaVenta.ToString() : notaCancelada[0].FechaVenta.ToString();
                ev.observaciones = notaRemision != null ? (notaRemision[0].Observaciones != null ? notaRemision[0].Observaciones : string.Empty) : notaCancelada[0].Observaciones;
                ev.total = notaRemision != null ? notaRemision[0].TotalVenta.ToString("0.00") : notaCancelada[0].TotalVenta.ToString("0.00");
                ev.notaRemision = true;
                ev.marcaDeAgua = "NOTA DE VENTA";
                if (notaRemision != null ? notaRemision[0].IdStatusOrden == IdentificadoresCatalogos.StatusOrden.CANCELADO.GetHashCode()
                    : notaCancelada[0].IdStatusOrden == IdentificadoresCatalogos.StatusOrden.CANCELADO.GetHashCode())
                {
                    ev.estaCancelada = true;
                }
                else
                {
                    ev.estaCancelada = false;
                }
            }
            else if (notasEntrega != null)
            {
                tituloNota = "Entrega: " + notasEntrega[0].IdNotaRemision.ToString();
                ordenPedido = "Orden de Pedido: " + notasEntrega[0].IdOrdenPedido.ToString();
                tituloNota = tituloNota + "\n" + ordenPedido;
                tipoPago = "Tipo de Pago: " + notasEntrega[0].TipoPago;
                fecha = notasEntrega[0].FechaGeneracion.ToString();
                ev.observaciones = notasEntrega[0].Observaciones != null ? notasEntrega[0].Observaciones.ToString() : "";
                ev.total = notasEntrega[0].Total.Value.ToString("0.00");
                ev.notaRemision = false;
                ev.marcaDeAgua = "ENTREGA";

                if (notasEntrega[0].IdStatusRemision == IdentificadoresCatalogos.StatusOrden.CANCELADO.GetHashCode())
                {
                    ev.estaCancelada = true;
                }
                else
                {
                    ev.estaCancelada = false;
                }
            }
            else
            {
                numeroDocumento = notaCredito[0].IdNotaCredito;
                tituloNota = "Nota de Credito: " + notaCredito[0].IdNotaCredito.ToString();
                if (notaCredito[0].IdOrdenPedido > 0)
                {
                    tituloNota = tituloNota + "\n" + "Orden Pedido:" + notaCredito[0].IdOrdenPedido;
                }
                tituloNota = tituloNota + "\n" + ordenPedido;
                tipoPago = string.Empty;
                fecha = notaCredito[0].Fecha.ToString();
                ev.observaciones = notaCredito[0].Observaciones != null ? notaCredito[0].Observaciones.ToString() : "";
                ev.total = notaCredito[0].Total.Value.ToString("0.00");
                ev.notaRemision = true;
                ev.marcaDeAgua = "NOTA DE CRÉDITO";
                ev.estaCancelada = false;
            }
            archivoPdf.PageEvent = ev;
            //CREAR DOCUCMENTO
            documento.Open();
            FontFactory.RegisterDirectories();
            //agregando el cuerpo del pdf en HTML
            PdfPCell cel = new PdfPCell();
            var v_fuenteTitulo = FontFactory.GetFont("Helvetica", 14, Font.BOLD);
            var v_fuentesubTitulo = FontFactory.GetFont("Helvetica", 9, Font.NORMAL);
            var v_fuenteObservacion = FontFactory.GetFont("Helvetica", 9, Font.NORMAL, new BaseColor(0, 2, 249, 1));
            var v_fuenteConcepto = FontFactory.GetFont("Helvetica", 9, Font.NORMAL | Font.UNDERLINE);
            var v_fuenteEtiquetas = FontFactory.GetFont("Helvetica", 9, Font.UNDERLINE);
            var v_fuenteSmall = FontFactory.GetFont("Helvetica", 8, Font.NORMAL);
            var v_fuente10N = FontFactory.GetFont("Helvetica", 10, Font.BOLD);
            var v_fuentesBold = FontFactory.GetFont("Helvetica", 10, Font.BOLD);
            var v_fuentesubTituloNormal = FontFactory.GetFont("Helvetica", 10, Font.NORMAL);
            Font fuenteEncabezado = new Font(FontFactory.GetFont("Arial").Family, 9f);
            Font fuenteEncabezadoBold = new Font(FontFactory.GetFont("Arial Black", 9, Font.BOLD, BaseColor.BLACK));
            Font totalNotasCredito = new Font(FontFactory.GetFont("Helvetica", 9, Font.NORMAL, BaseColor.RED));
            float v_paddingCeldas = 10f;
            iTextSharp.text.BaseColor color = new iTextSharp.text.BaseColor(System.Drawing.Color.FromArgb(189, 189, 189));

            //contenido
            float[] headerwidthsR_Prod = null;
            if (notasEntrega == null)
            {
                headerwidthsR_Prod = new float[] { 15f, 15f, 40f, 15f, 15f };
            }
            else
            {
                headerwidthsR_Prod = new float[] { 15f, 15f, 70f };
            }

            PdfPTable tblVentaProd = new PdfPTable(headerwidthsR_Prod.Count());
            //tblVentaProd.WidthPercentage = 100;
            tblVentaProd.SetTotalWidth(headerwidthsR_Prod);
            tblVentaProd.TotalWidth = documento.PageSize.Width;
            /*Si es mayor a 115 determinar cuantos renglones mas faltan dividiendo entre 110 la longitud de la direccion
            cuando ya se sabe el resultado de la division sumar 9 al espacio original en este caso 106*/
            /*--------------------------------------------------------
            if (notaRemision != null || notaCancelada != null)
            {
                tblVentaProd.SpacingBefore = 127;
            }
            else if (notasEntrega != null)
            {
                if (ev.direccion == null)
                {
                    tblVentaProd.SpacingBefore = 129;
                }
                else
                {
                    if (Convert.ToDouble(ev.direccion.Count()) / 70 > 1)
                    {
                        int sumar = 0;
                        if (ev.direccion.Count() % 70 == 0)
                        {
                            sumar = ev.direccion.Count() / 70;
                            tblVentaProd.SpacingBefore = 137 + 9 * sumar;
                        }
                        else
                        {
                            sumar = Convert.ToInt32(ev.direccion.Count() / 70);
                            tblVentaProd.SpacingBefore = 137 + 9 * sumar;
                        }
                    }
                    else
                    {
                        tblVentaProd.SpacingBefore = 129;
                    }
                }
            }
            else if (notaCredito != null)
            {
                if (notaCredito[0].IdOrdenPedido == 0)
                {
                    if (ev.direccion == null)
                    {
                        tblVentaProd.SpacingBefore = 130;
                    }
                    else
                    {
                        if (Convert.ToDouble(ev.direccion.Count()) / 70 > 1)
                        {
                            int sumar = 0;
                            if (ev.direccion.Count() % 70 == 0)
                            {
                                sumar = ev.direccion.Count() / 70;
                                tblVentaProd.SpacingBefore = 130 + 9 * sumar;
                            }
                            else
                            {
                                sumar = Convert.ToInt32(ev.direccion.Count() / 70);
                                tblVentaProd.SpacingBefore = 130 + 9 * sumar;
                            }
                        }
                        else
                        {
                            tblVentaProd.SpacingBefore = 130;
                        }
                    }
                }
                else
                {
                    if (ev.direccion == null)
                    {
                        tblVentaProd.SpacingBefore = 141;
                    }
                    else
                    {
                        if (Convert.ToDouble(ev.direccion.Count()) / 70 > 1)
                        {
                            int sumar = 0;
                            if (ev.direccion.Count() % 70 == 0)
                            {
                                sumar = ev.direccion.Count() / 70;
                                tblVentaProd.SpacingBefore = 166 + 9 * sumar;
                            }
                            else
                            {
                                sumar = Convert.ToInt32(ev.direccion.Count() / 70);
                                tblVentaProd.SpacingBefore = 166 + 9 * sumar;
                            }
                        }
                        else
                        {
                            tblVentaProd.SpacingBefore = 141;
                        }
                    }
                }
            }
            /*--------------------------------------------------------
            //Encabezado 
            PdfPTable tblEncabezado = new PdfPTable(3);
            float[] headerwidthsEncabezado = { 33.33f, 33.33f, 33.33f };
            tblEncabezado.SetTotalWidth(headerwidthsEncabezado);
            tblEncabezado.TotalWidth = documento.PageSize.Width;
            tblEncabezado.SpacingBefore = 30;
            //if (notaRemision)
            //{
            //    tblEncabezado.SpacingBefore = 15; 
            //} 
            //else 
            //{ 
            //    tblEncabezado.SpacingBefore = 5; 
            //}
            cel = new PdfPCell(new Phrase("Tels: 01(773) 7333623 y 7330349", v_fuentesubTituloNormal));
            cel.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            cel.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            tblEncabezado.AddCell(cel);
            cel = new PdfPCell(new Phrase(tipoPago, v_fuentesubTituloNormal));
            cel.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cel.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            tblEncabezado.AddCell(cel);
            Phrase tituloNotas = new Phrase();
            tituloNotas.Add(new Phrase(tituloNota, v_fuenteNumeroDocto));
            tituloNotas.Add(new Paragraph(Environment.NewLine));
            tituloNotas.Add(new Phrase(fecha, v_fuentesubTituloNormal));
            cel = new PdfPCell(tituloNotas);
            cel.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cel.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            tblEncabezado.AddCell(cel);
            documento.Add(tblEncabezado);
            //Datos del cliente 
            PdfPTable tblDatosCliente = new PdfPTable(1);
            //tblDatosCliente.WidthPercentage = 100; 
            tblDatosCliente.TotalWidth = documento.PageSize.Width;
            Phrase cliente = new Phrase("Cliente: ", v_fuentesBold);
            Phrase datos = new Phrase(nombreCliente, v_fuentesubTituloNormal);
            Phrase celCliente = new Phrase();
            celCliente.Add(cliente);
            celCliente.Add(datos);
            cel = new PdfPCell(celCliente);
            cel.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tblDatosCliente.AddCell(cel);
            Phrase direccionTitulo = new Phrase("Dirección: ", v_fuentesBold);
            datos = new Phrase(direccion, v_fuentesubTituloNormal);
            Phrase celDireccion = new Phrase();
            celDireccion.Add(direccionTitulo);
            celDireccion.Add(datos);
            cel = new PdfPCell(celDireccion);
            cel.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tblDatosCliente.AddCell(cel);
            Phrase rfcTitulo = new Phrase("R.F.C: ", v_fuentesBold);
            datos = new Phrase(rfc, v_fuentesubTituloNormal);
            Phrase celRfc = new Phrase();
            celRfc.Add(rfcTitulo);
            celRfc.Add(datos);
            cel = new PdfPCell(celRfc);
            cel.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tblDatosCliente.AddCell(cel);
            documento.Add(tblDatosCliente);
          
            if (notaRemision != null || notaCredito != null || notaCancelada != null)
            {
                //tblVentaProd.SpacingBefore = ev.direccionHeader-1; 
                ev.direccionFooter = ev.direccionFooter - 1;
                ev.HeaderSecondPage = ev.HeaderSecondPage - 1;
            }
            else
            {
                //tblVentaProd.SpacingBefore = ev.direccionHeader; 
            }

            PdfPCell celda = new PdfPCell();
            celda = new PdfPCell(new Phrase("Cantidad", v_fuentesubTitulo));
            celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            celda.BackgroundColor = color;
            tblVentaProd.AddCell(celda);
            celda = new PdfPCell(new Phrase("Unidad", v_fuentesubTitulo));
            celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            celda.BackgroundColor = color;
            tblVentaProd.AddCell(celda);
            celda = new PdfPCell(new Phrase("Descripción", v_fuentesubTitulo));
            celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            celda.BackgroundColor = color;
            tblVentaProd.AddCell(celda);

            if (notasEntrega == null)
            {
                celda = new PdfPCell(new Phrase("Precio Unitario", v_fuentesubTitulo));
                celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                celda.BackgroundColor = color;
                tblVentaProd.AddCell(celda);
                celda = new PdfPCell(new Phrase("Importe", v_fuentesubTitulo));
                celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                celda.BackgroundColor = color;
                tblVentaProd.AddCell(celda);
            }
            return null;
        }

        private static void eliminaArchivosPdf(string rutaArchivo)
        {

            throw new NotImplementedException();
        }
    }



    public class VW_VENT_NOTAS_CREDITO
    {
        public string Nombre { get; internal set; }
        public string Direccion { get; internal set; }
        public string Rfc { get; internal set; }
        public double? Total { get; set; }
        public int IdNotaCredito { get; internal set; }
        public int IdOrdenPedido { get; internal set; }
        public object Fecha { get; internal set; }
        public object Observaciones { get; internal set; }
    }

    public class VW_VENT_NOTAS_ENTREGA
    {
        public string Nombre { get; internal set; }
        public dynamic Direccion { get; internal set; }
        public string Rfc { get; internal set; }
        public int? Total { get; internal set; }
        public object IdNotaRemision { get; internal set; }
        public object IdOrdenPedido { get; internal set; }
        public string TipoPago { get; internal set; }
        public object FechaGeneracion { get; internal set; }
        public object Observaciones { get; internal set; }
        public object IdStatusRemision { get; internal set; }
    }

    public class VW_VENTAS_CLIENTE_CANCELADAS
    {
        public int? IdNotaVenta { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Rfc { get; set; }
        public int TotalVenta { get; set; }
        public string TipoPago { get; set; }
        public object FechaVenta { get; set; }
        public object Observaciones { get; set; }
        public object IdStatusOrden { get; set; }
    }

    public class VW_VENTAS_CLIENTE
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Rfc { get; set; }
        public int TotalVenta { get; set; }
        public int?  IdNotaVenta { get; set; }
        public string TipoPago { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Observaciones { get; set; }
        public string IdStatusOrden { get; set; }



    */
    }
}