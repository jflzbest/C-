using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace image2
{
        public class PDFSharpImages : Base
    {

        public PDFSharpImages(PdfDocument documnet)
            : base(documnet)
        {
        }

        public void DrawImage(XGraphics gfx, string jpegSamplePath)
        {
            // BeginBox(gfx, number, "DrawImage (original)");


            XImage image = XImage.FromFile(jpegSamplePath);
            double x = (gfx.PageSize.Width - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
            double y = (gfx.PageSize.Height - image.PixelHeight * 72 / image.VerticalResolution) / 2;
            gfx.DrawImage(image, x, y);

            //  EndBox(gfx);
        }
    }

}


