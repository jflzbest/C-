using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication3
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
        private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder returnvalue,int buffersize,string filepath);

        private string IniFilePath;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "男";
            for (int i = 1; i <= 100; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }
            comboBox2.Text = "18";
            IniFilePath = Application.StartupPath + "\\Config.ini";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Trim() != "") && (textBox2.Text.Trim() != ""))
            {
                string Section = "Information";
                try
                {
                    WritePrivateProfileString(Section, "Name", textBox1.Text.Trim(), IniFilePath);
                    WritePrivateProfileString(Section, "Gender", comboBox1.Text, IniFilePath);
                    WritePrivateProfileString(Section, "Age", comboBox2.Text, IniFilePath);
                    WritePrivateProfileString(Section, "Region", textBox2.Text.Trim(), IniFilePath);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
            {
                MessageBox.Show("姓名或地区不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string outString;
            try
            {
                GetValue("Information", "Name", out outString);
                textBox1.Text = outString;
                GetValue("Information", "Gender", out outString);
                comboBox1.Text = outString;
                GetValue("Information", "Age", out outString);
                comboBox2.Text = outString;
                GetValue("Information", "Region", out outString);
                textBox2.Text = outString;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void GetValue(string section,string key, out string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            GetPrivateProfileString(section, key, "", stringBuilder, 1024, IniFilePath);
            value = stringBuilder.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "男";
            comboBox2.Text = "18";
            textBox2.Text = "";
        }
    }
}
