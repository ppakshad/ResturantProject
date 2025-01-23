using System;                           using System.Text.RegularExpressions;
using System.Collections.Generic;       using System.ComponentModel;
using System.Data;                      using System.Drawing;
using System.Linq;                      using System.Text;
using System.Threading.Tasks;           using System.Windows.Forms;
using System.IO;                        using System.Net;
using System.Net.Mail;

namespace Resturant
{
    public partial class Form4 : Form
    {
        int S=0,n=0;
        public struct Amaar
        {
            public string SOS;
            public string NOS;
        }
        public Form4() {InitializeComponent(); }
        List<Amaar> List1 = new List<Amaar>();
        public static void OpenNewFrom() { Application.Run(new Login()); }
        public static void OpenNewFrom1() { Application.Run(new SendingEmail()); }
        public static void OpenNewFrom2() { Application.Run(new Personals()); }
        public void taabe()
        {
            StreamReader sr2 = new StreamReader(@"D:\Resturant\Fish\Bill.txt");
            string[] hold2 = sr2.ReadToEnd().Split('*');
            for (int i = 0; i < hold2.Length; i++)
            {
                string[] t = hold2[i].Split(' ');
                Amaar c = new Amaar();
                c.SOS = t[0];
                c.NOS = t[1];
                List1.Add(c);
            }
            for (int i = 0; i < List1.Count-1; i++)
            {
                S = S + (Convert.ToInt16(List1[i].SOS));
                n = n + (Convert.ToInt16(List1[i].NOS));
            }
            foreach (Amaar b in List1)
                listBox1.Items.Add(b.SOS);
            //listBox1.Items.Add(S);
            //listBox1.Items.Add(n);
            sr2.Close();
        }
        private void button1_Click(object sender, EventArgs e)                      //Backup Button
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@"F:\Backup");
                if (dir.Exists)
                    Console.WriteLine("error");
                else
                    dir.Create();
                File.Copy(@"D:\Resturant\Food\Food.txt", @"F:\Backup\Food.txt", true);
                File.Copy(@"D:\Resturant\Fish\Bill.txt", @"F:\Backup\Bill.txt", true);
                File.Copy(@"D:\Resturant\Eshterak\Eshterak.txt", @"F:\Backup\Eshterak.txt", true);
                File.Copy(@"D:\Resturant\Eshterak\Emails.txt", @"F:\Backup\Emails.txt", true);
                File.Copy(@"D:\Resturant\Personal\Personal.txt", @"F:\Backup\Personal.txt", true);
                MessageBox.Show("Backup is Compelet", "Done",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            catch
            {
                MessageBox.Show("Exists Error!!", "Error");
            }
        }
        private void button2_Click(object sender, EventArgs e)                      //LogOut Button
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
            mythread.Start();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)                      //SendEmail Button
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom1));
            mythread.Start();
            this.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            taabe();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom2));
            mythread.Start();
            this.Close();
        }
    
    }
}
