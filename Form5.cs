using System;                           using iTextSharp;
using System.Collections.Generic;       using iTextSharp.text;
using System.ComponentModel;            using iTextSharp.text.pdf;
using System.Data;                      using System.Media;
using System.Drawing;                   using System.Linq;
using System.Text;                      using System.Threading.Tasks;
using System.Windows.Forms;


namespace Resturant
{
    public partial class Form5 : Form
    {
        public Form5() { InitializeComponent();}
        public static void OpenNewFrom() { Application.Run(new Form6()); }
        public static void OpenNewFrom1() { Application.Run(new MenuEdit()); }
        public static void OpenNewFrom2() { Application.Run(new Login()); }
        public static void OpenNewFrom3() { Application.Run(new Teraket()); }
        private void button1_Click(object sender, EventArgs e)                  //Open Form6 
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
            mythread.Start();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)                  //opening new form
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom1));
            mythread.Start();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)                  //Open Login
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom2));
            mythread.Start();
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)                  //Open Teraket
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom3));
            mythread.Start();
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }               
    }
}
