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
using System.Media;
using System.IO;

namespace Resturant
{
    public partial class Login : Form
    {
        public Login() {InitializeComponent();}
        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\Resturant");                     // Sakhte Folder
            if (dir.Exists)
                Console.WriteLine("error");
            else
                dir.Create();
            DirectoryInfo dir1 = new DirectoryInfo(@"D:\Resturant\Eshterak");
            if (dir1.Exists)
                Console.WriteLine("error");
            else
                dir1.Create();
            DirectoryInfo dir2 = new DirectoryInfo(@"D:\Resturant\Fish");
            if (dir2.Exists)
                Console.WriteLine("error");
            else
                dir2.Create();
            DirectoryInfo dir3 = new DirectoryInfo(@"D:\Resturant\Food");
            if (dir3.Exists)
                Console.WriteLine("error");
            else
                dir3.Create();
            DirectoryInfo dir4 = new DirectoryInfo(@"D:\Resturant\Personal");
            if (dir4.Exists)
                Console.WriteLine("error");
            else
                dir4.Create();
            //SoundPlayer player = new SoundPlayer();
            //string path = "C:\\windows\\media\\Level1-orkestr.wav";
            //player.SoundLocation = path;
            //player.Play();
        }
        public static void OpenNewFrom(){ Application.Run(new ManagementLogin());}      //Opening new form's
        public static void OpenNewFrom1(){ Application.Run(new PersonnelLogin());}

        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
            mythread.Start();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom1));
            mythread.Start();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e){Login y = new Login(); AboutBox1 u = new AboutBox1(); y.Hide(); u.Show();}
        private void button4_Click(object sender, EventArgs e) { Environment.Exit(0); }
        
    }
}
