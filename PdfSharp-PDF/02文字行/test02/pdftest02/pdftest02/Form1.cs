using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace pdftest02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PdfDocument document = new PdfDocument();

        document.Info.Title = "Created with PDFsharp";

      // Create an empty page
      PdfPage page = document.AddPage();

        // Get an XGraphics object for drawing
        XGraphics gfx = XGraphics.FromPdfPage(page);

        //XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

        // Create a font
        //XFont font = new XFont("Times New Roman", 20, XFontStyle.BoldItalic);
        System.Drawing.Text.PrivateFontCollection pfcFonts = new System.Drawing.Text.PrivateFontCollection();
        string strFontPath = @"C:/Windows/Fonts/msyh.ttf";//字体设置为微软雅黑
        pfcFonts.AddFontFile(strFontPath);

      XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
        XFont font = new XFont(pfcFonts.Families[0], 15, XFontStyle.Regular, options);
        //PdfWriter.Wirte()里的断言注释掉

        // Draw the text
        gfx.DrawString("你好, 世界!", font, XBrushes.Black,new XRect(0,0, page.Width, page.Height),XStringFormats.Center);

      // Save the document...
      //const string filename = "PDF\\HelloWorld_tempfile2.pdf";
      string _path = YZRHelper.RPath.GetPath(System.AppDomain.CurrentDomain.BaseDirectory, 2) + "\\PDF\\YZR.pdf";
        document.Save(_path);
      // ...and start a viewer.
      Process.Start(_path);

    }
}
