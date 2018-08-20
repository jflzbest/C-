using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xiepdf
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            string imagePath1;
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new addl());

            imagePath1 = "H:/haixt111/图片/1Rose (RGB 8).tif";
            try
            {
                PdfDocument doc = new PdfDocument();
                PdfPage page = doc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                //addl a = new addl();
                //a.AddLogo(gfx, page, imagePath1, 50, 300);
                AddLogo(gfx, page, imagePath1, 50, 300);

                //文字
                string strFontPath = @"C:/Windows/Fonts/simhei.ttf";
                System.Drawing.Text.PrivateFontCollection pfcFonts = new System.Drawing.Text.PrivateFontCollection();
                pfcFonts.AddFontFile(strFontPath);
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
                XFont font = new XFont(pfcFonts.Families[0], 15, XFontStyle.Regular, options);

                
                string st1 = "乳腺癌HE检测报告";
                XFont font1 = new XFont(pfcFonts.Families[0], 20, XFontStyle.Regular, options);
                //string st = Regex.Replace(stt, @"\S{10}", "$0\r\n");
                 gfx.DrawString(st1, font1, XBrushes.Black,
                       new XRect(0, 10, page.Width, page.Height),
                       XStringFormats.TopCenter);//乳腺癌HE检测报告Center

                string st2 = "姓名：";
                gfx.DrawString(st2, font, XBrushes.Black,
                        new XRect(30, 50, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st3 = "性别：";
                gfx.DrawString(st3, font, XBrushes.Black,
                        new XRect(230, 50, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st4 = "年龄：";
                gfx.DrawString(st4, font, XBrushes.Black,
                        new XRect(430, 50, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st4d = "岁";
                gfx.DrawString(st4d, font, XBrushes.Black,
                        new XRect(510, 50, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st5 = "报告日期：";
                gfx.DrawString(st5, font, XBrushes.Black,
                        new XRect(30, 90, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st6 = "科别：";
                gfx.DrawString(st6, font, XBrushes.Black,
                        new XRect(300, 90, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st7 = "住院号：";
                gfx.DrawString(st7, font, XBrushes.Black,
                        new XRect(30, 130, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st8 = "病理号：";
                gfx.DrawString(st8, font, XBrushes.Black,
                        new XRect(300, 130, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st9 = "送检单位：";
                gfx.DrawString(st9, font, XBrushes.Black,
                        new XRect(30, 170, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st10 = "检测结果：";
                gfx.DrawString(st10, font, XBrushes.Black,
                        new XRect(30, 210, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st11 = "结果附图：";
                gfx.DrawString(st11, font, XBrushes.Black,
                        new XRect(30, 250, page.Width, page.Height),
                        XStringFormats.TopLeft);
                
                string st12 = "结果评价:";
                gfx.DrawString(st12, font, XBrushes.Black,
                        new XRect(30, 630, page.Width, page.Height),
                        XStringFormats.TopLeft);
                //string stt = "首先，我们的商业模式不同，京东是一个整合的平台，也就是说我们有直营系统，也有市场模式；第二，我们非常关注用户体验，就像我说的，我们只给顾客卖真货，提供最快的快递服务，这让我们和中国的其他竞争对手都不一样，在场的大部分人都知道阿里巴巴，但是如果你们试试在中国购物，你们永远都不会忘记京东。";
                //string st = Regex.Replace(stt, @"\S{10}", "$0\r\n");
                //gfx.DrawString(st, font, XBrushes.Black,
                //      new XRect(0, 0, page.Width, page.Height),
                //      XStringFormats.TopLeft);
                string st13 = "报告医师：";
                gfx.DrawString(st13, font, XBrushes.Black,
                        new XRect(350, 800, page.Width, page.Height),
                        XStringFormats.TopLeft);
                //文字止

                //格式框
                XTextFormatter tf = new XTextFormatter(gfx);
                string st12d = "评价内容";
                XRect rect = new XRect(30, 650, 550, 150);
                gfx.DrawRectangle(XBrushes.WhiteSmoke, rect);
                tf.Alignment = XParagraphAlignment.Left;
                tf.DrawString(st12d, font, XBrushes.Black, rect, XStringFormats.TopLeft);
             //格式框止
                
                const string filename = "Hello test.pdf";
                doc.Save(filename);
                Process.Start(filename);

            }
            catch (Exception)
            {
                // Handle exception
            }
            void AddLogo(XGraphics gfx, PdfPage page, string imagePath, int xPosition, int yPosition)
            {

                if (!File.Exists(imagePath))
                {
                    throw new FileNotFoundException(String.Format("Could not find image {0}.", imagePath));
                }

                XImage xImage = XImage.FromFile(imagePath);

                gfx.DrawImage(xImage, xPosition, yPosition, xImage.PixelWidth / 3.24, xImage.PixelWidth / 5);//3.24  5
                                                                                                             //gfx.ScaleTransform(0.15);
            }
        }
    }
}
