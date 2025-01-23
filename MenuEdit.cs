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

namespace Resturant
{
    public partial class MenuEdit : Form
    {
        public MenuEdit() {InitializeComponent();}
        public static void OpenNewFrom() { Application.Run(new Form5()); }
        public struct Food
        {
            public string name;
            public string price;
            public string number;
            public string NOF;
            public Image pic;
        }
        List<Food> mylist = new List<Food>();
        public void update()                                            //taabe ye menu e ghaza
        {
            while (listBox1.Items.Count > 0)                       //Jologiri Az Add Dobare :D
                listBox1.Items.RemoveAt(0);
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Resturant\Food\Food.txt");
            for (int i = 0; i < mylist.Count-1; i++)                  //Adding Food To A File
            {
                string test = i + " " + mylist[i].name + " " + mylist[i].price+"*";
                file.Write(test);
            }
            file.Write( mylist.Count-1 + " " + mylist[mylist.Count - 1].name + " " + mylist[mylist.Count-1].price );
            foreach (Food b in mylist)
                listBox1.Items.Add(b.name);
            file.Close();
        }
        private void button1_Click(object sender, EventArgs e)          //Add Button
        {
            Food a = new Food();
            a.name = textBox1.Text;
            a.price = textBox2.Text;
            mylist.Add(a);
            update();
        }
        private void button2_Click(object sender, EventArgs e)          //Remove Button
        {
            try
            {
                foreach (Food a in mylist)
                {
                    if (a.name == textBox1.Text.ToString())
                    {
                        mylist.Remove(a);
                        break;
                    }
                }
                update();
            }
            catch (Exception er) {MessageBox.Show(er.Message);}
        }
        private void button3_Click(object sender, EventArgs e)          //Back button
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
            mythread.Start();
            this.Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Food a in mylist)
                {
                    if (a.name == listBox1.SelectedItem.ToString())
                    {
                        label1.Text = a.name;
                        label2.Text = a.price;
                        //pictureBox1.Image = a.pic;
                        break;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void MenuEdit_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"D:\Resturant\Food\Food.txt");
            string[] hold = sr.ReadToEnd().Split('*');
            for (int i = 0; i < hold.Length; i++)
            {
                string[] t = hold[i].Split(' ');
                Food a = new Food();
                a.number = t[0];
                a.name = t[1];
                a.price = t[2];
                mylist.Add(a);
            }
            foreach (Food b in mylist)
                listBox1.Items.Add(b.name);
            sr.Close();
            update();
            MessageBox.Show("For Adding Food Plz Write the Name & Price Of the Food & click Add Button, For Removing A Food Write it's Name & Click Remove Button", "Guide",
            MessageBoxButtons.OK,
            MessageBoxIcon.None,
            MessageBoxDefaultButton.Button1);
        }
    }
}