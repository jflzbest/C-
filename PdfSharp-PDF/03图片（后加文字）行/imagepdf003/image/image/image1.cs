#region PDFsharp - A .NET library for processing PDF
//
// Copyright (c) 2005-2009 empira Software GmbH, Cologne (Germany)
//
// http://www.pdfsharp.com
//
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT OF THIRD PARTY RIGHTS.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
// USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using System.Diagnostics;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;

namespace image
{
    /// <summary>
    /// Shows how to draw images.
    /// </summary>
    
    public class Images : Base
    {
        //const string jpegSamplePath = "../../../../../../dev/XGraphicsLab/images/Z3.jpg";
        //const string gifSamplePath = "../../../../../../dev/XGraphicsLab/images/Test.gif";
        //const string pngSamplePath = "../../../../../../dev/XGraphicsLab/images/Test.png";
        //const string tiffSamplePath = "../../../../../../dev/XGraphicsLab/images/Rose (RGB 8).tif";

        //const string tiffSamplePath = "H:/haixt111/201615477-3-1@4.tif";
        //const string pdfSamplePath = "H:/haixt111/SomeLayout.pdf";
        const string jpegSamplePath = "H:/haixt111/图片/1Rose (RGB 8).tif";
        const string SamplePath = "H:/haixt111/图片/1Rose (RGB 8).tif";
        

        public void DrawPage(PdfPage page)
        {
            XGraphics gfx = XGraphics.FromPdfPage(page);

            DrawTitle(page, gfx, "Images");
            
            //DrawImage(gfx, 1);
            //DrawImageScaled(gfx, 2);
            //DrawImageRotated(gfx, 3);
            //DrawImageSheared(gfx, 4);
            //DrawGif(gfx, 5);
            //DrawPng(gfx, 6);
            //DrawTiff(gfx, 5);
            DrawFormXObject(gfx,6);

            string strFontPath = @"C:/Windows/Fonts/simhei.ttf";
            System.Drawing.Text.PrivateFontCollection pfcFonts = new System.Drawing.Text.PrivateFontCollection();
            //string strFontPath = @"C:/Windows/Fonts/msyhl.ttc";
            pfcFonts.AddFontFile(strFontPath);
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XFont font = new XFont(pfcFonts.Families[0], 30, XFontStyle.Regular, options);//.Families[0], 15

            //Document document1 = new Document();
            //Style style = document1.Styles["Normal"];
            //style.Font = new MigraDoc.DocumentObjectModel.Font(pfcFonts.Families[0].Name, 12);

            // Create a new PDF document
            //PdfDocument document = new PdfDocument();
            //document.Info.Title = "Created with PDFsharp";

            //// Create an empty page
            //PdfPage page = document.AddPage();

            //// Get an XGraphics object for drawing
            //XGraphics gfx = XGraphics.FromPdfPage(page);
            string st = "pdf测试文字";
            gfx.DrawString(st, font, XBrushes.Black,
            new XRect(200, 100, page.Width, page.Height),
            XStringFormats.Center);

            ////格式框
            //XTextFormatter tf = new XTextFormatter(gfx);

            //XRect rect = new XRect(310, 100, 250, 232);
            //gfx.DrawRectangle(XBrushes.SeaShell, rect);
            //tf.Alignment = XParagraphAlignment.Right;
            //tf.DrawString(st, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            ////格式框止

            //// Save the document...
            //const string filename = "HelloWorld_tempfile.pdf";
            //document.Save(filename);
            //// ...and start a viewer.
            //Process.Start(filename);

        }

        //文字



        //文字止
        /// <summary>
        /// Draws an image in original size.
        /// </summary>
        void DrawImage(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawImage (original)");

            XImage image = XImage.FromFile(jpegSamplePath);

            // Left position in point
            double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
            gfx.DrawImage(image, x, 0);

            EndBox(gfx);
        }

        /// <summary>
        /// Draws an image scaled.
        /// </summary>
        //void DrawImageScaled(XGraphics gfx, int number)
        //{
        //    BeginBox(gfx, number, "DrawImage (scaled)");

        //    XImage image = XImage.FromFile(jpegSamplePath);
        //    gfx.DrawImage(image, 0, 0, 250, 140);

        //    EndBox(gfx);
        //}

        /// <summary>
        /// Draws an image transformed.
        ///// </summary>
        //void DrawImageRotated(XGraphics gfx, int number)
        //{
        //    BeginBox(gfx, number, "DrawImage (rotated)");

        //    XImage image = XImage.FromFile(jpegSamplePath);

        //    const double dx = 250, dy = 140;

        //    gfx.TranslateTransform(dx / 2, dy / 2);
        //    gfx.ScaleTransform(0.7);
        //    gfx.RotateTransform(-25);
        //    gfx.TranslateTransform(-dx / 2, -dy / 2);

        //    //XMatrix matrix = new XMatrix();  //XMatrix.Identity;

        //    double width = image.PixelWidth * 72 / image.HorizontalResolution;
        //    double height = image.PixelHeight * 72 / image.HorizontalResolution;

        //    gfx.DrawImage(image, (dx - width) / 2, 0, width, height);

        //    EndBox(gfx);
        //}

        ///// <summary>
        ///// Draws an image transformed.
        ///// </summary>
        //void DrawImageSheared(XGraphics gfx, int number)
        //{
        //    BeginBox(gfx, number, "DrawImage (sheared)");

        //    XImage image = XImage.FromFile(jpegSamplePath);

        //    const double dx = 250, dy = 140;

        //    //XMatrix matrix = gfx.Transform;
        //    //matrix.TranslatePrepend(dx / 2, dy / 2);
        //    //matrix.ScalePrepend(-0.7, 0.7);
        //    //matrix.ShearPrepend(-0.4, -0.3);
        //    //matrix.TranslatePrepend(-dx / 2, -dy / 2);
        //    //gfx.Transform = matrix;

        //    gfx.TranslateTransform(dx / 2, dy / 2);
        //    gfx.ScaleTransform(-0.7, 0.7);
        //    gfx.ShearTransform(-0.4, -0.3);
        //    gfx.TranslateTransform(-dx / 2, -dy / 2);

        //    double width = image.PixelWidth * 72 / image.HorizontalResolution;
        //    double height = image.PixelHeight * 72 / image.HorizontalResolution;

        //    gfx.DrawImage(image, (dx - width) / 2, 0, width, height);

        //    EndBox(gfx);
        //}

        ///// <summary>
        ///// Draws a GIF image with transparency.
        ///// </summary>
        //void DrawGif(XGraphics gfx, int number)
        //{
        //    this.backColor = XColors.LightGoldenrodYellow;
        //    this.borderPen = new XPen(XColor.FromArgb(202, 121, 74), this.borderWidth);
        //    BeginBox(gfx, number, "DrawImage (GIF)");

        //    XImage image = XImage.FromFile(gifSamplePath);

        //    const double dx = 250, dy = 140;

        //    double width = image.PixelWidth * 72 / image.HorizontalResolution;
        //    double height = image.PixelHeight * 72 / image.HorizontalResolution;

        //    gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

        //    EndBox(gfx);
        //}

        ///// <summary>
        ///// Draws a PNG image with transparency.
        ///// </summary>
        //void DrawPng(XGraphics gfx, int number)
        //{
        //    BeginBox(gfx, number, "DrawImage (PNG)");

        //    XImage image = XImage.FromFile(pngSamplePath);

        //    const double dx = 250, dy = 140;

        //    double width = image.PixelWidth * 72 / image.HorizontalResolution;
        //    double height = image.PixelHeight * 72 / image.HorizontalResolution;

        //    gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

        //    EndBox(gfx);
        //}

        ///// <summary>
        ///// Draws a TIFF image with transparency.
        ///// </summary>
        //void DrawTiff(XGraphics gfx)// gfx, int number)
        //{
        //    //XColor oldBackColor = this.backColor;
        //    //this.backColor = XColors.LightGoldenrodYellow;
        //    BeginBox(gfx, number, "DrawImage (TIFF)");

        //    XImage image = XImage.FromFile(SamplePath);

        //    const double dx = 2, dy = 2;

        //    double width = image.PixelWidth * 12 / image.HorizontalResolution;
        //    double height = image.PixelHeight * 7 / image.HorizontalResolution;

        //    gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

        //    EndBox(gfx);
        //    //this.backColor = oldBackColor;
        //}

        ///// <summary>
        ///// Draws a form XObject (a page from an external PDF file).
        ///// </summary>
        void DrawFormXObject(XGraphics gfx, int number)
        {
            //this.backColor = XColors.LightSalmon;
            BeginBox(gfx, number, " ");

            XImage image = XImage.FromFile(SamplePath);

            //const double dx = 250, dy = 140;
            const double dx = 2, dy = 2;

            gfx.TranslateTransform(dx / 2, dy / 2);
            //gfx.ScaleTransform(0.35);
            gfx.ScaleTransform(0.15);
            gfx.TranslateTransform(-dx / 2, -dy / 2);

            double width = image.PixelWidth * 56 / image.HorizontalResolution;
            double height = image.PixelHeight * 43 / image.HorizontalResolution;

            gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

            EndBox(gfx);
        }
    }
}
