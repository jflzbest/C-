using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
namespace wordPDF1
{
    class ImageHelper
    {
        Image image = Image.FromFile("H:/haixt111/图片/test.jpg");
        Bitmap bitmap = new Bitmap("H:/haixt111/图片/test.jpg");
        public static byte[] ImageToBytes(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        internal static void AppendImageToPdf(byte[] buffer, byte[] buffer1, int v1, int v2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// Convert Byte[] to a picture and Store it in file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        
        public static string CreateImageFromBytes(string fileName, byte[] buffer)
        {
            string file = fileName;
            Image image = BytesToImage(buffer);
            ImageFormat format = image.RawFormat;
            if (format.Equals(ImageFormat.Jpeg))
            {
                file += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Png))
            {
                file += ".png";
            }
            else if (format.Equals(ImageFormat.Bmp))
            {
                file += ".bmp";
            }
            else if (format.Equals(ImageFormat.Gif))
            {
                file += ".gif";
            }
            else if (format.Equals(ImageFormat.Icon))
            {
                file += ".icon";
            }
            System.IO.FileInfo info = new System.IO.FileInfo(file);
            System.IO.Directory.CreateDirectory(info.Directory.FullName);
            File.WriteAllBytes(file, buffer);
            return file;
        }

        public static byte[] AppendImageToPdf(byte[] pdf, byte[] img, Point position, double scale)
        {
            using (System.IO.MemoryStream msPdf = new System.IO.MemoryStream(pdf))
            {
                using (System.IO.MemoryStream msImg = new System.IO.MemoryStream(img))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(msImg);
                    PdfSharp.Pdf.PdfDocument document = PdfSharp.Pdf.IO.PdfReader.Open(msPdf);
                    PdfSharp.Pdf.PdfPage page = document.Pages[0];
                    PdfSharp.Drawing.XGraphics gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                    PdfSharp.Drawing.XImage ximg = PdfSharp.Drawing.XImage.FromGdiPlusImage(image);

                    gfx.DrawImage(
                        ximg,
                        position.X,
                        position.Y,
                        ximg.Width * scale,
                        ximg.Height * scale
                    );

                    using (System.IO.MemoryStream msFinal = new System.IO.MemoryStream())
                    {
                        document.Save(msFinal);
                        return msFinal.ToArray();
                    }

                }
            }
        }

    }
}
