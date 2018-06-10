using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace Test01
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Document doc = new Document(PageSize.A4, 50, 50, 80, 50);
            MemoryStream Memory = new MemoryStream();
            PdfWriter PdfWriter = PdfWriter.GetInstance(doc, Memory);

            BaseFont bfChinese = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font ChFont = new Font(bfChinese, 12);
            Font ChFont_blue = new Font(bfChinese, 40, Font.NORMAL, new BaseColor(51, 0, 153));
            Font ChFont_msg = new Font(bfChinese, 12, Font.ITALIC, new BaseColor(51, 0, 153));

            doc.Open();
            doc.Add(new Paragraph(10f, "DIDILONG!", ChFont_blue));
            doc.Close();

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=pdfExample.pdf");
            Response.ContentType = "application/octet-stream";
            Response.OutputStream.Write(Memory.GetBuffer(), 0, Memory.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.End();
        }


        public static void ValidateJwtWithHs256(String encodedJwt, String base64EncodedSecret, String validAudience, String validIssuer)
        {
            var secretKey = new SymmetricSecurityKey(Endoding.UTF8.GetBytes("a secret that needs to be at least 16 characters long"));
            var tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningToken = new BinarySecretSecurityToken(Base64UrlEncoder.DecodeBytes(base64EncodedSecret)),
                ValidIssuer = validIssuer,
                ValidAudience = validAudience,
            };
            SecurityToken securityToken;
            new JwtSecurityTokenHandler().ValidateToken(encodedJwt, tokenValidationParameters, out securityToken);
        }
    }
}