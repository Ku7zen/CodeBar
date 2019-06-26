using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace Reportes.resourses
{
    public class GenerarPDF
    {
        Codigo_barra cb = new Codigo_barra();
      
        public GenerarPDF()
        {
             
        }
        public MemoryStream Cpdf(List<Tuple<string, MemoryStream>> codigos)
        {

            /*===================Generamos el pdf definimos nombre, titulo y dimenciones del documento==============*/
            Document doc = new Document(PageSize.LEGAL);
            // Indicamos donde vamos a guardar el documento

            // PdfWriter writer1 = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\Asus.DESKTOP-6M8SH9U\Documents\pdfc\prueba.pdf", FileMode.Create));

            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);

            writer.Open();
            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Etiquetas PDF");
            doc.AddCreator("RTROG");
            // Abrimos el archivo
            doc.Open(); 
 
            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Codigos de barra"));
            doc.Add(Chunk.NEWLINE);
             
            /*================Cierre de archivo para finalizar y guardar nuestro documento=================*/

            byte[] byteStream = ms.ToArray();
            ms.Write(byteStream, 0, byteStream.Length);
            ms.Position = 0;
            //writer.Close();
            return ms;

        }
        public MemoryStream CreaPDF(List<Tuple<string,MemoryStream>> codigos) {

            /*===================Generamos el pdf definimos nombre, titulo y dimenciones del documento==============*/
            Document doc = new Document(PageSize.LEGAL);
            // Indicamos donde vamos a guardar el documento

           // PdfWriter writer1 = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\Asus.DESKTOP-6M8SH9U\Documents\pdfc\prueba.pdf", FileMode.Create));
             
            MemoryStream ms = new MemoryStream();
           PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            
            writer.Open();
            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Etiquetas PDF");
            doc.AddCreator("RTROG");
            // Abrimos el archivo
            doc.Open();
            //Generar formato de ho




            /*======================Agregar informacion al documento =========================*/
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Codigos de barra"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(4);
            tblPrueba.WidthPercentage = 113;


            System.Web.UI.WebControls.Image imgcode;
            foreach (Tuple<string,MemoryStream> id in codigos)
            {
                //imgcode = cb.crear(id.Item1);
                // Configuramos el título de las columnas de la tabla
                PdfPCell columna1 = new PdfPCell(new Phrase("etiqueta", _standardFont));
                columna1.BorderWidth = 0;
                columna1.BorderWidthBottom = 0.10f;

                PdfPCell columna2 = new PdfPCell(new Phrase("etiqueta", _standardFont));
                columna2.BorderWidth = 0;
                columna2.BorderWidthBottom = 0.10f;

                PdfPCell columna3 = new PdfPCell(new Phrase("etiqueta", _standardFont));
                columna3.BorderWidth = 0;
                columna3.BorderWidthBottom = 0.10f;


                PdfPCell columna4 = new PdfPCell(new Phrase("etiqueta", _standardFont));
                columna4.BorderWidth = 0;
                columna4.BorderWidthBottom = 0.10f;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(columna1);
                tblPrueba.AddCell(columna2);
                tblPrueba.AddCell(columna3);
                tblPrueba.AddCell(columna4);

                // Llenamos la tabla con información
                //columna1 = new PdfPCell(new System.Web.UI.WebControls.Image(imgcode));
                //System.Drawing.Image bitmap = new System.Drawing.Bitmap(100, 100);
                //System.Drawing.Image bitmap = new System.Web.UI.WebControls.Image(imgcode);
                //System.Web.UI.WebControls.Image img = new System.Drawing.Image(id.Item2);
                //new System.Web.UI.WebControls.Image()

                //columna1 = new PdfPCell( iTextSharp.text.Image.GetInstance(id.Item2.GetBuffer()));
                //columna1.Image = iTextSharp.text.Image.GetInstance()
                //float[] w = new float[1];
                //w[0] = 10;
                //tblPrueba.SetWidths(w);
                //columna1.BorderWidth = 1;
                //columna1.VerticalAlignment = Element.ALIGN_TOP;
                //columna1.HorizontalAlignment = Element.ALIGN_LEFT;

                columna2 = new PdfPCell(new Phrase(id + "T*", _standardFont));
                columna2.BorderWidth = 1;

                columna3 = new PdfPCell(new Phrase("P*", _standardFont));
                columna3.BorderWidth = 1;
                 
                columna4 = new PdfPCell(new Phrase("Z*", _standardFont));
                columna4.BorderWidth = 1;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(columna1);
                tblPrueba.AddCell(columna2);
                tblPrueba.AddCell(columna3);
                tblPrueba.AddCell(columna4);
                
                doc.Add(tblPrueba);

            }
           
            /*================Cierre de archivo para finalizar y guardar nuestro documento=================*/
            
            byte[] byteStream = ms.ToArray();
            ms.Write(byteStream,0,byteStream.Length);
            ms.Position = 0;
            //writer.Close();
            return ms;

        } 
    }
}