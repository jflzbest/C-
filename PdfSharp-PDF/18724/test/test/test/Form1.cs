using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text = "dsfg";
            Thread t1 = new Thread(Testc);
            t1.IsBackground = true;
            t1.Start();
        }

        void Testc()
        {
            for (int i=0; i < 1000; i++)
            {
                //Console.WriteLine(i);
                textBox1.Text=i.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                Thread th = new Thread(ChangeText);
                th.Name = "new Thread!";
                th.IsBackground = true;
                th.Start();
            
        }
        void ChangeText()
            {
                //Thread.Sleep(3000);
                MethodInvoker ln = new MethodInvoker(Change);
                this.BeginInvoke(ln);
            }
        void Change()
            {
                textBox1.Text = "进入子线程！";
            }
    }
}
