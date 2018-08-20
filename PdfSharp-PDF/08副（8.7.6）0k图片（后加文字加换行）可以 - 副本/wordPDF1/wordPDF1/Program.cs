using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wordPDF1
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
            Image image = Image.FromFile("H:/haixt111/图片/test.jpg");
            Image p = Image.FromFile("H:/haixt111/图片/123.pdf");
            Bitmap bitmap = new Bitmap("H:/haixt111/图片/test.jpg");

            byte[] buffer,buffer1;
            buffer=ImageHelper.ImageToBytes(image);
            buffer1 = ImageHelper.ImageToBytes(p);
            //image=ImageHelper.BytesToImage(buffer);
            //string fileName = "H:/haixt111/图片/123.pdf";
            //ImageHelper.CreateImageFromBytes(fileName, buffer);
            ImageHelper.AppendImageToPdf(buffer, buffer1, 10, 20);



            //string fileName="H:/haixt111/图片";
            //ImageHelper.CreateImageFromBytes()
            //Application.Run(new ImageHelper());
            //ImageHelper im = new ImageHelper();
            //im.ImageToBytes(image);





        }
        //public static byte[] AppendImageToPdf(byte[] pdf, byte[] img, Point position, double scale)
        //string image = "H:/haixt111/图片/1Rose (RGB 8).tif";
        


    }
}
