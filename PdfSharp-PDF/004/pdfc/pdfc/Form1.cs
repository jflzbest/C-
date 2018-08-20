using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;


namespace pdfc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void Render(XGraphics gfx)
        {

            XRect rect;
            XPen pen;
            double x = 50, y = 100;
            XFont fontH1 = new XFont("华文仿宋 常规", 18, XFontStyle.Bold);//华文仿宋
            XFont font = new XFont("华文仿宋 常规", 12);//Arial  必须是中文字体

            //XFont fontH1 = new XFont("微软雅黑", 18, XFontStyle.Bold);//华文仿宋
            //XFont font = new XFont("微软雅黑", 12);//Arial  必须是中文字体

            XFont fontItalic = new XFont("Arial Unicode MS", 12, XFontStyle.BoldItalic);
            double ls = 14;// font.GetHeight(gfx);   //GetHeight

            // Draw some text
            gfx.DrawString("Create PDF on the fly with PDFsharp  中国文",
                fontH1, XBrushes.Black, x, x);
            gfx.DrawString("With PDFsharp you can use the same code to draw graphic, " +
                "text and images on different targets.涂聚文，捷为工作室", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString("The object used for drawing is the XGraphics object.",
                font, XBrushes.Black, x, y);
            y += 2 * ls;

            // Draw an arc
            pen = new XPen(XColors.Red, 4);
            pen.DashStyle = XDashStyle.Dash;
            gfx.DrawArc(pen, x + 20, y, 100, 60, 150, 120);

            // Draw a star          

            gfx.TranslateTransform(x + 140, y + 30);
            for (int idx = 0; idx < 360; idx += 10)
            {
                gfx.RotateTransform(10);
                gfx.DrawLine(XPens.DarkGreen, 0, 0, 30, 0);
            }

            XGraphicsState gs = gfx.Save();
            gfx.Restore(gs);


            // Draw a rounded rectangle
            rect = new XRect(x + 230, y, 100, 60);
            pen = new XPen(XColors.DarkBlue, 2.5);
            XColor color1 = XColor.FromKnownColor(XKnownColor.DarkBlue);//  //XColor.FromKnownColor(KnownColor.DarkBlue);
            XColor color2 = XColors.Red;
            XLinearGradientBrush lbrush = new XLinearGradientBrush(rect, color1, color2,
              XLinearGradientMode.Vertical);
            gfx.DrawRoundedRectangle(pen, lbrush, rect, new XSize(10, 10));

            // Draw a pie
            pen = new XPen(XColors.DarkOrange, 1.5);
            pen.DashStyle = XDashStyle.Dot;
            gfx.DrawPie(pen, XBrushes.Blue, x + 360, y, 100, 60, -130, 135);
            //没有自动分行
            // Draw some more text
            y += 60 + 2 * ls;
            gfx.DrawString("With XGraphics you can draw on a PDF page as well as " +
                "on any System.Drawing.Graphics object.", font, XBrushes.Black, x, y);
            y += ls * 1.1;
            gfx.DrawString("Use the same code to", font, XBrushes.Black, x, y);
            x += 10;
            y += ls * 1.1;
            gfx.DrawString("• draw on a newly created PDF page", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString("• draw above or beneath of the content of an existing PDF page",
                font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString("• draw in a window", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString("• draw on a printer", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString("• draw in a bitmap image", font, XBrushes.Black, x, y);
            x -= 10;
            y += ls * 1.1;
            gfx.DrawString("You can also import an existing PDF page and use it like " +
                "an image, e.g. draw it on another PDF page.", font, XBrushes.Black, x, y);
            y += ls * 1.1 * 2;
            gfx.DrawString("Imported PDF pages are neither drawn nor printed; create a " +
                "PDF file to see or print them!", fontItalic, XBrushes.Firebrick, x, y);
            y += ls * 1.1;
            gfx.DrawString("Below this text is a PDF form that will be visible when " +
                "viewed or printed with a PDF viewer.", fontItalic, XBrushes.Firebrick, x, y);
            y += ls * 1.1;
            //XGraphicsState state = gfx.Save();
            //gfx.Restore(state);
            XRect rcImage = new XRect(100, y, 100, 100 * Math.Sqrt(2));
            gfx.DrawRectangle(XBrushes.Snow, rcImage);
            gfx.DrawImage(XPdfForm.FromFile("bicycle.pdf"), rcImage);

            XGraphicsState states = gfx.Save();
            gfx.Restore(states);


        }
        /// <summary>
        ///
        /// </summary>

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

            // Create an empty page
            PdfPage page = document.AddPage();
            //page.Contents.CreateSingleContent().Stream.UnfilteredValue;

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);
            Render(gfx);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                document.Save(saveFileDialog1.FileName);
                Process.Start(saveFileDialog1.FileName);
            }

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>

    }
}
