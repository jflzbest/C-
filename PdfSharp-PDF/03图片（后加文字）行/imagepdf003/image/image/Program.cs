using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel;

namespace image
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        internal static PdfDocument s_document;
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            


            




            // Create a temporary file
            string filename = String.Format("{0}_tempfile.pdf", Guid.NewGuid().ToString("D").ToUpper());
            s_document = new PdfDocument();
            s_document.Info.Title = "PDFsharp XGraphic Sample";
            //s_document.Info.Author = "Stefan Lange";
            //s_document.Info.Subject = "Created with code snippets that show the use of graphical functions";
            //s_document.Info.Keywords = "PDFsharp, XGraphics";

            // Create demonstration pages
            //new LinesAndCurves().DrawPage(s_document.AddPage());
            //new Shapes().DrawPage(s_document.AddPage());
            //new Paths().DrawPage(s_document.AddPage());
            //new Text().DrawPage(s_document.AddPage());
            new Images().DrawPage(s_document.AddPage());

            // Save the s_document...

            //s_document.Save(filename);

            ////文字
            //string strFontPath = @"C:/Windows/Fonts/simhei.ttf";
            //System.Drawing.Text.PrivateFontCollection pfcFonts = new System.Drawing.Text.PrivateFontCollection();
            //pfcFonts.AddFontFile(strFontPath);
            //XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            //XFont font = new XFont(pfcFonts.Families[0], 15, XFontStyle.Regular, options);

            ////Document document1 = new Document();
            ////Style style = document1.Styles["Normal"];
            ////style.Font = new MigraDoc.DocumentObjectModel.Font(pfcFonts.Families[0].Name, 12);

            //// Create a new PDF document
            //PdfDocument document = new PdfDocument();
            //document.Info.Title = "Created with PDFsharp";

            //// Create an empty page
            //PdfPage page = document.AddPage();

            //// Get an XGraphics object for drawing
            //XGraphics gfx = XGraphics.FromPdfPage(page);
            //gfx.DrawString("可奈嘛顶国另顶替硒鼓二替顶热月报表月报表何", font, XBrushes.Black,
            //            new XRect(100, 300, page.Width, page.Height),
            //            XStringFormats.Center);
            ////文字止





            // Save the document...
            //const string filename = "HelloWorld_tempfile.pdf";
            s_document.Save(filename);
            // ...and start a viewer.
            //Process.Start(filename);


            // ...and start a viewer
            Process.Start(filename);
        }

        //

    }
    
}
