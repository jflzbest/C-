using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace image2
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            #region image Sample
            string filename = "HelloWorld.pdf";
            PdfDocument document = new PdfDocument();
            string path = "H:/haixt111/图片/1Rose (RGB 8).tif";
            //// Create an empty page
            //Image image = Image.FromFile(path);
            PDFSharpImages PDFImage = new PDFSharpImages(document);
            //PDFImage.DrawImage(document, image,10, 10);
            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;

            //    ////// Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XImage image = XImage.FromFile(path);
            const double dx =4, dy = 4;
            gfx.TranslateTransform(dx / 2, dy / 2);
            //gfx.ScaleTransform(0.35);
            gfx.ScaleTransform(0.3);
            gfx.TranslateTransform(-dx / 2, -dy / 2);

            double width = image.PixelWidth * 30 / image.HorizontalResolution;
            double height = image.PixelHeight * 30 / image.HorizontalResolution;

            gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

            //PDFImage.DrawImage(gfx, path);
            document.Save(filename);
            //// ...and start a viewer.
            Process.Start(filename);
            #endregion

        }
    }
}
