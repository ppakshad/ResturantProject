using System;   
using System.Collections.Generic;
using System.ComponentModel;            using System.Data;
using System.Drawing;                   using System.Linq;
using System.Text;                      using System.Threading.Tasks;
using System.Windows.Forms;             using System.IO;
using iTextSharp;                       using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Resturant
{
    public partial class Menu : Form
    {
        int sum = 0,SONOF=0;
        public Menu(){InitializeComponent();}
        public static void OpenNewFrom() { Application.Run(new Form5()); }
        public struct Food
        {
            public string name;
            public string price;
            public string number;
            public string NOF;
            //public Image pic;
        }
        List<Food> mylist = new List<Food>();       //For ListBox1
        List<Food> mylist2= new List<Food>();       //For ListBox2
        public void update()
        {
            while (listBox2.Items.Count > 0)
                listBox2.Items.RemoveAt(0);
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Resturant\Fish\Fish.txt");
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"D:\Resturant\Fish\Bill.txt",true);
            Document oDoc = new Document(PageSize.A6.Rotate());
            PdfWriter.GetInstance(oDoc, new FileStream(@"D:\Resturant\Fish\Fish.pdf", FileMode.Create));
            oDoc.Open();
            for (int i = 0; i < mylist2.Count-1; i++    )
            {
                string test = i + "    " + mylist2[i].name + "    " + mylist2[i].NOF + "    " + mylist2[i].price;          //what to write in file in "Txt" & "PDF"
                file.WriteLine(test);oDoc.Add(new Paragraph(test));
            }
            file.WriteLine(mylist2.Count - 1 + "\t" + mylist2[mylist2.Count - 1].name + "\t" + mylist2[mylist2.Count - 1].NOF + "\t" + mylist2[mylist2.Count - 1].price);   //for the last food adding .txt
            oDoc.Add(new Paragraph(mylist2.Count - 1 + "    " + mylist2[mylist2.Count - 1].name + "    " + mylist2[mylist2.Count - 1].NOF + "    " + mylist2[mylist2.Count - 1].price));  //for the last food adding .txt
            for (int i = 0; i < mylist2.Count; i++)
            {
                sum += Convert.ToInt16(mylist2[i].NOF) * Convert.ToInt16(mylist2[i].price);
            }
            file.WriteLine("\n\t\t\tThe Sum is:" + sum);
            for (int i = 0; i < mylist2.Count; i++)
                SONOF += Convert.ToInt16(mylist2[i].NOF);
            file1.Write(sum+" "+SONOF+"*");
            oDoc.Add(new Paragraph("\n\t\tThe Sum is:" + sum));
            file.Close(); oDoc.Close(); file1.Close();
        }
        private void Menu_Load(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)                  //Ordered Food's(Add Button)
        {
            Food a=new Food();                              //Adding Food To ListBox2
            a.NOF = numericUpDown1.Value.ToString();
            a.name = listBox1.SelectedItem.ToString();
            a.price = label2.Text;
            listBox2.Items.Add(a.name);
            mylist2.Add(a);
        }
        private void button2_Click(object sender, EventArgs e)                  //(Done Button)
        {
            try
            {
                update();
                MessageBox.Show("Thank's For Chosing Us :)", "Done",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1);
                //bool tryStart = false;bool connected = false;                     //Printing The PDF File
                //do
                //{
                //    try
                //    {
                //        client.Connect();
                //        connected = true;
                //    }
                //    catch (DdeException)
                //    {
                //        // try running Adobe Reader
                //        System.Diagnostics.Process p = new System.Diagnostics.Process();
                //        p.StartInfo.FileName = "AcroRd32.exe";
                //        p.Start();
                //        p.WaitForInputIdle();
                //        // try this once
                //        tryStart = !tryStart;
                //    }
                //} while (tryStart && !connected);
                //if (connected)
                //{
                //    client.Execute("[DocOpen(\@"D:\Resturant\Fish\Fish.pdf\")]", 60000);
                //    client.Execute("[FilePrintSilent(\@"D:\Resturant\Fish\Fish.pdf\")]", 60000);
                //    client.Execute("[DocClose(\@"D:\Resturant\Fish\Fish.pdf\")]", 60000);
                //    client.Execute("[AppExit]", 60000);
                //}

                System.Diagnostics.Process.Start(@"D:\Resturant\Fish\Fish.pdf");
                System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
                mythread.Start();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ocurred Error","Error!!");
            }
        }
        private void button3_Click(object sender, EventArgs e)                  //Back Button
        {
            System.Threading.Thread mythread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenNewFrom));
            mythread.Start();
            this.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
