using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturant
{
    public partial class Teraket : Form
    {
        public static void OpenNewFrom8() { Application.Run(new Form5()); }
        public Teraket()
        {
            InitializeComponent();
        }

        private void TerAkett_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom8));
            mythread.Start();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
