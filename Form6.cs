using System;                               using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Media;
using System.Threading;

namespace Resturant
{
    public partial class Form6 : Form
    {
        public Form6(){InitializeComponent();}
        public static void OpenNewFrom() { Application.Run(new Menu()); }
        public static void OpenNewFrom1() { Application.Run(new Form5()); }
        private void Form6_Load(object sender, EventArgs e)
        {
            DateTime dt;
            dt = DateTime.UtcNow;
            label4.Text = dt.ToString();
        }
        private void button3_Click(object sender, EventArgs e)                                          //Checking Number that it is in system or not!
        {
            System.IO.StreamReader reader = System.IO.File.OpenText(@"D:\Resturant\Eshterak\Eshterak.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line.Contains(textBox1.Text))
                {
                    MessageBox.Show("We have this phone number.", "Hello",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                    System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
                    mythread.Start();
                    this.Close();
                    break;
                }
            }
            MessageBox.Show("Your number is not in our system", "Sorry",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
            reader.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, @"^\d{8}$") && (Regex.IsMatch(textBox2.Text, @"@Yahoo.com$") || Regex.IsMatch(textBox2.Text, @"@Gmail.com$") || Regex.IsMatch(textBox2.Text, @"@yahoo.com$") || Regex.IsMatch(textBox2.Text, @"@gmail.com$")))
            {
                textBox2.Visible = true; textBox3.Visible = true;
                label2.Visible = true; label3.Visible = true;
                StreamWriter sw = new StreamWriter(@"D:\Resturant\Eshterak\Eshterak.txt", true);
                StreamWriter sw1 =new StreamWriter(@"D:\Resturant\Eshterak\Emails.txt", true);
                sw.WriteLine("\n");
                sw.Write("-------------------------------------------------------");
                sw.WriteLine("\n");
                sw.Write(textBox1.Text);
                sw.WriteLine("\n");
                sw.Write(textBox2.Text);
                sw.WriteLine("\n");
                sw1.Write(textBox2.Text);
                sw1.Write("*");
                sw.Write(textBox3.Text);
                sw.Close(); sw1.Close();
                System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
                mythread.Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sth Is Wrong (Phone number should be 8 numbers & Email should have @ ... .com), Try Again Plz", "Error",
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
