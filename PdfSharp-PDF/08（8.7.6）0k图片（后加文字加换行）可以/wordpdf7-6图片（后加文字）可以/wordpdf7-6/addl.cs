using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wordpdf7_6
{
    public partial class addl : Form
    {
        public addl()
        {
            InitializeComponent();
        }

        public void AddLogo(XGraphics gfx, PdfPage page, string imagePath, int xPosition, int yPosition)
        {

            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException(String.Format("Could not find image {0}.", imagePath));
            }

            XImage xImage = XImage.FromFile(imagePath);

            gfx.DrawImage(xImage, xPosition, yPosition, xImage.PixelWidth / 4, xImage.PixelWidth / 5);
            //gfx.ScaleTransform(0.15);
        }

    }
}
