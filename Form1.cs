using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crystal_Reports
{
    public partial class Form1 : Form
    {
        CrystalReport1 CR;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport1();

        }

        private void Generate_Report_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR;
        }

        private void bbutton1_Click(object sender, EventArgs e)
        {
            Crystal_Reports.MenuForm mf = new Crystal_Reports.MenuForm();
            mf.Show();
            this.Hide();
        }

        private void ebutton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
