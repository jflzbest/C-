using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using PdfSharp.Pdf.IO;
using System.IO;
using System.Web;
using MigraDoc.DocumentObjectModel;


namespace test01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            int LoopNum=0;
            LoopNum++;
            this.textBox1.Text += "第"+LoopNum.ToString()+"次循环" +"\r\n";
                // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "PDFSHARP测试";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

            System.Drawing.Text.PrivateFontCollection pfcFonts = new System.Drawing.Text.PrivateFontCollection();
            //string strFontPath = @"C:/Windows/Fonts/msyh.ttc";//字体设置为微软雅黑
            //string strFontPath = @"C:/Windows/Fonts/STFANGSO.TTF";
            //STFANGSO.TTF   STXINGKA.TTF
            string strFontPath = @"C:/Windows/Fonts/simhei.ttf";
            //string strFontPath = @"C:\Windows\Boot\Fonts\msyh_boot.ttf"; 
            //string strFontPath = HttpContext.Current.Server.MapPath("msyh.ttf");
            pfcFonts.AddFontFile(strFontPath);

            //Document document1 = new Document();
            //Style style = document1.Styles["Normal"];
            ////style.Font= new MigraDoc.DocumentObjectModel.Font(pfcFonts.Families[0].Name, 12);
            //style.Font.Color = Colors.Black;
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XFont font = new XFont(pfcFonts.Families[0], 15, XFontStyle.Regular, options);

            // Create a font
            //XFont font = new XFont("Times New Roman", 20, XFontStyle.BoldItalic);

            // Draw the text
            gfx.DrawString("efgdfgdsgf你好，病理 世界!这个世在 中枥加格达奇是dsfjsdf罟顶替顶替顶替一压死二百五上下遥", font, XBrushes.Black,new XRect(-240, -400, page.Width, page.Height),
            XStringFormats.Center);

            // Save the document...
            string filename = "HelloWorld_" + LoopNum.ToString() + ".pdf";
            //string _path = YZRHelper.RPath.GetPath(System.AppDomain.CurrentDomain.BaseDirectory, 2) + "\\PDF\\YZR.pdf";
            document.Save(filename);
            Process.Start(filename);
        }
    }
}
