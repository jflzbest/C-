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

namespace wordpdf7_6
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new addl());

            imagePath1 = "H:/haixt111/图片/1Rose (RGB 8).tif";
            try
            {
                PdfDocument doc = new PdfDocument();
                PdfPage page = doc.AddPage();

                XGraphics gfx = XGraphics.FromPdfPage(page);

                //AddLogo(gfx, invoice, "pathtoimage", 0, 0);
                addl a = new addl();
                a.AddLogo(gfx, page, imagePath1,100, 300);

                //文字
                string strFontPath = @"C:/Windows/Fonts/simhei.ttf";
                System.Drawing.Text.PrivateFontCollection pfcFonts = new System.Drawing.Text.PrivateFontCollection();
                //string strFontPath = @"C:/Windows/Fonts/msyhl.ttc";
                pfcFonts.AddFontFile(strFontPath);
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
                XFont font = new XFont(pfcFonts.Families[0], 15, XFontStyle.Regular, options);


                // html to pdf 

                string stt = "首先，我们的商业模式不同，京东是一个整合的平台，也就是说我们有直营系统，也有市场模式；第二，我们非常关注用户体验，就像我说的，我们只给顾客卖真货，提供最快的快递服务，这让我们和中国的其他竞争对手都不一样，在场的大部分人都知道阿里巴巴，但是如果你们试试在中国购物，你们永远都不会忘记京东。";

                //string source = "啊啊啊啊啊啊啊啊啊啊哦哦哦哦哦哦哦哦哦哦哦呵呵呵呵呵呵呵呵呵呵";
                //Regex reg = new Regex(@"(\S{10})");
                //source = reg.Replace(source, "$1\r\n");



                //string sst = @"商业模式不同，京东是一个整合的平台，也就是说我们有直营系统，也有市场模式；第二，我们非常关注用户体验，就像我说的，我们只给顾客卖真货，提供最快的快递服务，这让我们和中国的其他竞争对手都不一样，在场的大部分人都知道阿里";
                string st = Regex.Replace(stt, @"\S{10}", "$0\r\n");
                //string result = "";
                //for (int i = 0; i < st.Length; i++)
                //{
                //    if (i % 10 == 0)
                //        result = sst.Insert(i, "\r\n");

                //}
                //sst = result;

                //string addstr = "hello";
                //st.Insert(0, addstr);


                //string str = "qewdesdfdfdfd.txt";

                //string insertStr = "123hello12341212";

                //string result1 = str.Insert(1, insertStr);


                //MessageBox.Show(result1);

                //MessageBox.Show(st);                //MessageBox.Show(st);


                //gfx.DrawString(st, font, XBrushes.Black,
                //        new XRect(0, 0, page.Width, page.Height),
                //        XStringFormats.Center);

                gfx.DrawString(st, font, XBrushes.Black,
                       new XRect(0, 0, page.Width, page.Height),
                       XStringFormats.TopLeft);


                string st1 = "11替一ssdsfdff隔热压下 了压死压死压死压死月报表月报表何11";
                gfx.DrawString(st1, font, XBrushes.Black,
                        new XRect(-100, -100, page.Width, page.Height),
                        XStringFormats.Center);

                string st2 = "厉害厉害厉害厉害厉害厉害厉害厉害厉害厉害厉害厉害厉害厉害";
                gfx.DrawString(st2, font, XBrushes.Black,
                        new XRect(-100, 100, page.Width, page.Height),
                        XStringFormats.Center);
                //文字止

                //格式框
                XTextFormatter tf = new XTextFormatter(gfx);

                XRect rect = new XRect(210, 100, 280, 300);
                gfx.DrawRectangle(XBrushes.WhiteSmoke, rect);
                tf.Alignment = XParagraphAlignment.Right;
                tf.DrawString(st, font, XBrushes.Black, rect, XStringFormats.TopLeft);
                //格式框止


                const string filename = "Hello test.pdf";
                doc.Save(filename);
                Process.Start(filename);

            }
            catch (Exception)
            {
                // Handle exception
            }


            //string imagePath; //= "H:/haixt111/图片/1Rose (RGB 8).tif";
            



        }
    }
}
