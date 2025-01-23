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
    public partial class Menu : Form
    {
        public Menu() {InitializeComponent();}
        int x = 40,y=50;
        private void Form7_Load(object sender, EventArgs e)
        {
            Label label3 = new Label();
            label3.AutoSize = true;
            label3.Visible = true;
            label3.Show();
            this.Controls.Add(label3);
            label3.Text = ":D:D:D";
            label1.Location = new Point(x, y);
            label2.Location = new Point(x, label1.Location.Y + 25);
            label3.Location = new Point(x, label2.Location.Y + 25);
            //this.Controls.Remove();
            
        }
    }
}