using Reportes.resourses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reportes
{
    public partial class index : System.Web.UI.Page
    {
        List<Tuple<string,MemoryStream>> listEtiqueta ;
        GenerarPDF gp = new GenerarPDF();
        Codigo_barra cb = new Codigo_barra();
        String id = null;
        MemoryStream ms = new MemoryStream();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("datos_producto.aspx");
        }
        protected void genera_CodeBar(string barCode)
        {
            PlaceHolder1.Controls.Add(cb.crear(barCode, out ms));
            Session["ms"] = ms;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string barCode = TextBox1.Text;
            Regex Val = new Regex(@"^[+-]?\d+(\.\d+)?$");
            id = barCode;
            if (Val.IsMatch(barCode))
            {

                genera_CodeBar(barCode);

                Button3.Visible = true;
                Label1.Visible = true;
                //Label2.Visible = false;
                Session["Num"] = barCode;
            }
            else
            {
                Label2.Visible = true;
                Button3.Visible = false;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Extraer la clave (numero) para generar su codigo de barra respectivo
            if (Session["lista"] is null)
            {
                listEtiqueta = new List<Tuple<string, MemoryStream>>();
            }
            else
            {
                listEtiqueta = (List<Tuple<string, MemoryStream>>)Session["lista"];
            }
            listEtiqueta.Add(new Tuple<string, MemoryStream>(Session["Num"].ToString(), (MemoryStream)Session["ms"]));
            Session["lista"] = listEtiqueta;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            //Response.ContentType = "Application/pdf";
            //Response.BinaryWrite(gp.CreaPDF((List<Tuple<string, MemoryStream>>)Session["lista"]).GetBuffer());
            //Response.AppendHeader("Content-Disposition", "attachment; filename=File.pdf");
            //Response.End();
            Stream stm1 = new MemoryStream(gp.Cpdf((List<Tuple<string, MemoryStream>>)Session["lista"]).GetBuffer());
            //Stream stm1 = new MemoryStream(gp.CreaPDF((List<Tuple<string, MemoryStream>>)Session["lista"]).GetBuffer());
            Int16 bufferSize = 1024;
            byte[] buffer = new byte[bufferSize + 1];

            Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Octet;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"Report.pdf\";", "bar"));
            Response.BufferOutput = false;
            int count = stm1.Read(buffer, 0, bufferSize);

            while (count > 0)
            {
                Response.OutputStream.Write(buffer, 0, count);
                count = stm1.Read(buffer, 0, bufferSize);
            }
        }
    }
}