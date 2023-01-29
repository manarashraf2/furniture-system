using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5;

namespace Crystal_Reports
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void manageItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connected.Connected connectedMode = new Connected.Connected();
            this.Hide();
            connectedMode.Show();


        }

        private void addToCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApp3.addtocart disconnectedMode = new WindowsFormsApp3.addtocart();
            this.Hide();
            disconnectedMode.Show();
        }

        private void viewOrderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.Show();
        }

        private void viewCustomersDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 Cust_data = new Form1();
            this.Hide();
            Cust_data.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void exitbutton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
