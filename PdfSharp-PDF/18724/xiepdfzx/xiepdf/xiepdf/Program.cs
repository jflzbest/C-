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
            imagePath1 = "H:/haixt111/图片/1Rose (RGB 8).tif";
            void AddLogo(XGraphics gfx, PdfPage page, string imagePath, int xPosition, int yPosition)
            {

                if (!File.Exists(imagePath))
                {
                    throw new FileNotFoundException(String.Format("Could not find image {0}.", imagePath));
                }

                XImage xImage = XImage.FromFile(imagePath);

                gfx.DrawImage(xImage, xPosition, yPosition, xImage.PixelWidth /4.2, xImage.PixelWidth /5.8);//3.24  5 /3.7, xImage.PixelWidth / 5.8
                                                                                                             //gfx.ScaleTransform(0.15);
            }
            string teststrr = " 数量";
            int a=teststrr.Length;
            if(a>1)
            {
                MessageBox.Show("可以");

            }
            
            try
            {
                PdfDocument doc = new PdfDocument();
                PdfPage page = doc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                AddLogo(gfx, page, imagePath1, 30, 365);

                //文字
                //字体黑体simhei.ttf
                string strFontPath = @"C:/Windows/Fonts/simhei.ttf";
                System.Drawing.Text.PrivateFontCollection pfcFonts = new System.Drawing.Text.PrivateFontCollection();
                pfcFonts.AddFontFile(strFontPath);
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
                XFont font = new XFont(pfcFonts.Families[0], 15, XFontStyle.Regular, options);
                XFont fontd = new XFont(pfcFonts.Families[0], 20, XFontStyle.Regular, options);
                //字体华文仿宋STFANGSO.TTF
                string strFontPath1 = @"C:/Windows/Fonts/STFANGSO.TTF";
                System.Drawing.Text.PrivateFontCollection pfcFonts1 = new System.Drawing.Text.PrivateFontCollection();
                pfcFonts.AddFontFile(strFontPath1);
                XPdfFontOptions options1 = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
                XFont font1 = new XFont(pfcFonts.Families[0], 15, XFontStyle.Regular, options);


                string st1 = "乳腺癌HER2基因荧光原位杂交（FISH）检测报告";
                gfx.DrawString(st1, fontd, XBrushes.Black,
                       new XRect(0, 10, page.Width, page.Height),
                       XStringFormats.TopCenter);//乳腺癌HE检测报告Center

                string st2 = "姓名：";
                gfx.DrawString(st2, font, XBrushes.Black,
                        new XRect(30, 50, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st3 = "性别：";
                gfx.DrawString(st3, font, XBrushes.Black,
                        new XRect(240, 50, page.Width, page.Height),
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

                //检测结果
                string st10 = "检测结果：";
                gfx.DrawString(st10, font, XBrushes.Black,
                        new XRect(30, 210, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st10d1 = "HER2信号分布情况：";
                gfx.DrawString(st10d1, font1, XBrushes.Black,
                        new XRect(40, 230, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st10d2 = "点状分布：";
                gfx.DrawString(st10d2, font1, XBrushes.Black,
                        new XRect(40, 250, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st10d3 = "计数细胞个数：";
                gfx.DrawString(st10d3, font1, XBrushes.Black,
                        new XRect(120, 250, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string stq = "23";
                gfx.DrawString(stq, font, XBrushes.Black,
                        new XRect(220, 250, page.Width, page.Height),
                        XStringFormats.TopLeft);

                string st10d4 = "HER2信号总数：";
                gfx.DrawString(st10d4, font1, XBrushes.Black,
                        new XRect(330, 250, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st10d5 = "CSP17染色体信号数：";
                gfx.DrawString(st10d5, font1, XBrushes.Black,
                        new XRect(120, 270, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st10d6 = "HER2/CSP27比值：";
                gfx.DrawString(st10d6, font1, XBrushes.Black,
                        new XRect(330, 270, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st10d7 = "平均每个细胞HER2信号数：";
                gfx.DrawString(st10d7, font1, XBrushes.Black,
                        new XRect(120, 290, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st10d8 = "平均每个细胞CSP17信号数：";
                gfx.DrawString(st10d8, font1, XBrushes.Black,
                        new XRect(120, 310, page.Width, page.Height),
                        XStringFormats.TopLeft);
                //检测结果止

                string st11 = "结果附图：";
                gfx.DrawString(st11, font, XBrushes.Black,
                        new XRect(30, 340, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st12 = "结果评价:";
                gfx.DrawString(st12, font, XBrushes.Black,
                        new XRect(30, 650, page.Width, page.Height),
                        XStringFormats.TopLeft);
                string st13 = "报告医师：";
                gfx.DrawString(st13, font, XBrushes.Black,
                        new XRect(350, 800, page.Width, page.Height),
                        XStringFormats.TopLeft);
                //文字止

                //矩形格式框
                XTextFormatter tf = new XTextFormatter(gfx);
                string st12d = "评价内容";
                XRect rect = new XRect(30, 670, 550, 130);//30, 650, 550, 150);
                gfx.DrawRectangle(XBrushes.WhiteSmoke, rect);
                tf.Alignment = XParagraphAlignment.Left;
                tf.DrawString(st12d, font, XBrushes.Black, rect, XStringFormats.TopLeft);
                //矩形格式框止
                
                const string filename = "Hello test.pdf";
                doc.Save(filename);
                Process.Start(filename);

            }
            catch (Exception)
            {
                // Handle exception
            }
            
        }
    }
}
