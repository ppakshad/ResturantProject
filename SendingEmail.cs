using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Resturant
{
    public partial class SendingEmail : Form
    {
        public SendingEmail() {InitializeComponent(); }
        public static void OpenNewFrom() { Application.Run(new Form4()); }
        public struct Email
        {
            public string name;
        }
        List<Email> Emaillist = new List<Email>();
        private void SendingEmail_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"D:\Resturant\Eshterak\Emails.txt");
            string[] hold = sr.ReadToEnd().Split('*');
            for (int i = 0; i < hold.Length; i++)
            {
                string[] t = hold[i].Split(' ');
                Email a = new Email();
                a.name = t[0];
                Emaillist.Add(a);
            }
            foreach (Email b in Emaillist)
                listBox1.Items.Add(b.name);
            sr.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MailMessage object_mail = new MailMessage();                              //Sending Email Button
            //SmtpClient client = new SmtpClient();
            //client.Port = 25;
            //client.Host = "smtp.internal.erisson.com";
            //client.Timeout = 10000;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential();
            //object_mail.From = new MailAddress(textBox3.Text);
            //for (int i = 0; i < Emaillist.Count - 1; i++)                                  //Send Email To Who Are In Exist File
            //    object_mail.To.Add(new MailAddress(Emaillist[i].name));
            //object_mail.Subject = textBox1.Text;
            //object_mail.Body = textBox2.Text;
            //client.Send(object_mail);
            //MessageBox.Show("Email's Has Been Sent", "Done",
            //MessageBoxButtons.OK,
            //MessageBoxIcon.Information,
            //MessageBoxDefaultButton.Button1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
            mythread.Start();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
