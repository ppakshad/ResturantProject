using System;                           using System.IO;
using System.Collections.Generic;       using System.ComponentModel;
using System.Data;                      using System.Drawing;
using System.Linq;                      using System.Text;
using System.Threading.Tasks;           using System.Windows.Forms;

namespace Resturant
{
    public partial class Personals : Form
    {
        public Personals() { InitializeComponent(); }
        public static void OpenNewFrom15() { Application.Run(new Form4()); }
        public struct Personal
        {
            public string name;
            public string familyname;
            public string Phonenumber;
            public string salary;
        }
        List<Personal> Plist = new List<Personal>();
        public void update()                                            //taabe ye menu e ghaza
        {
            while (listBox1.Items.Count > 0)                       //Jologiri Az Add Dobare :D
                listBox1.Items.RemoveAt(0);
            System.IO.StreamWriter Pfile = new System.IO.StreamWriter(@"D:\Resturant\Personal\Personal.txt");
            for (int i = 0; i < Plist.Count - 1; i++)
            {
                string test = Plist[i].familyname + " " + Plist[i].name + " " + Plist[i].salary + " " + Plist[i].Phonenumber + "*";
                Pfile.Write(test);
            }
            Pfile.Write(Plist[Plist.Count - 1].familyname + " " + Plist[Plist.Count - 1].name + " " + Plist[Plist.Count - 1].salary + " " + Plist[Plist.Count - 1].Phonenumber);
            foreach (Personal b in Plist)
                listBox1.Items.Add(b.familyname);
            Pfile.Close();
        }
        private void Personals_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"D:\Resturant\Personal\Personal.txt");
            string[] hold = sr.ReadToEnd().Split('*');
            for (int i = 0; i < hold.Length; i++)
            {
                string[] t = hold[i].Split(' ');
                Personal a = new Personal();
                a.familyname = t[0];
                a.name = t[1];
                a.salary = t[2];
                a.Phonenumber= t[3];
                Plist.Add(a);
            }
            foreach (Personal b in Plist)
                listBox1.Items.Add((b.familyname));
            sr.Close();
            update();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Personal a in Plist)
                {
                    if (a.familyname == listBox1.SelectedItem.ToString())
                    {
                        label6.Text = a.name;
                        label7.Text = a.familyname;
                        label8.Text = a.salary;
                        label9.Text = a.Phonenumber;
                        break;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)                  //Add Button
        {
            Personal a = new Personal();
            a.familyname = textBox1.Text;
            a.name = textBox2.Text;
            a.salary = textBox4.Text;
            a.Phonenumber = textBox3.Text;
            Plist.Add(a);
            update();
            MessageBox.Show("Personal Added :)", "Done",
            MessageBoxButtons.OK,
            MessageBoxIcon.None,
            MessageBoxDefaultButton.Button1);
        }
        private void button2_Click(object sender, EventArgs e)                  //Remove Button
        {
            try
            {
                update();

                foreach (Personal a in Plist)
                {
                    if (a.name == textBox2.Text.ToString() && a.familyname==textBox1.Text.ToString())
                    {
                        Plist.Remove(a);
                        break;
                    }
                }
                
                MessageBox.Show("Personal Removed :|", "Done",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1);
                
            }
            catch (Exception er) { MessageBox.Show(er.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom15));
            mythread.Start();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       
    }
}
