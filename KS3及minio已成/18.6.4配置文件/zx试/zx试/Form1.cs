using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace zx试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filepath);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder returnvalue, int buffersize, string filepath);

        public string IniFilePath;

        IniFilePath = Application.StartupPath + "\\Config.ini";
        private void button1_Click(object sender, EventArgs e)
        {
            string outString;
            try
            {
                GetValue("Information", "Name", out outString);
                textBox1.Text = outString;
                //GetValue("Information", "Gender", out outString);
                //comboBox1.Text = outString;
                //GetValue("Information", "Age", out outString);
                //comboBox2.Text = outString;
                //GetValue("Information", "Region", out outString);
                //textBox2.Text = outString;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void GetValue(string section, string key, out string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            GetPrivateProfileString(section, key, "", stringBuilder, 1024, IniFilePath);
            value = stringBuilder.ToString();
        }

    }
}
