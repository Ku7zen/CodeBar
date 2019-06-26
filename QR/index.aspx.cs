using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing; 
using MessagingToolkit.QRCode.Codec;
using QR.PDF;

namespace QR
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap img = encoder.Encode(txtCode.Text);
            System.Drawing.Image QR = (System.Drawing.Image)img;
            using (MemoryStream ms = new MemoryStream())
            {
                QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                imgCtrl.Src = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);
                imgCtrl.Height = 200;
                imgCtrl.Width = 200;

                Generador generaPDF = new Generador();
                generaPDF.ToString();

            }
        }
    }
}