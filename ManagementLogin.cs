using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text.RegularExpressions;
using System.Media;

namespace Resturant
{
    public partial class ManagementLogin : Form
    {
        public ManagementLogin() { InitializeComponent(); }
        public static void OpenNewFrom() { Application.Run(new Form4()); }
        public static void OpenNewFrom1() { Application.Run(new Login()); }
        private void button1_Click(object sender, EventArgs e)                          //Management Login
        {
            string username1 = "puya";
            string password1 = "1414";
            if ((textBox1.Text == username1) && (textBox2.Text == password1) && Regex.IsMatch(textBox2.Text, @"^\d{4}$"))
            {
                System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
                mythread.Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("You Enter Password or Username Wrong!", "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom1));
            mythread.Start();
            this.Close();
        }
    }
}
