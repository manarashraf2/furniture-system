using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Crystal_Reports.Reports;
namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        CrystalReport2 CR;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport2();
            foreach (ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
            {

                cusidcomboBox1.Items.Add(v.Value);
            }
        }

        private void reportbutton1_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, cusidcomboBox1.Text);
            crystalReportViewer2.ReportSource = CR;
        }

        private void backbutton2_Click(object sender, EventArgs e)
        {
            Crystal_Reports.MenuForm mf = new Crystal_Reports.MenuForm();
            mf.Show();
            this.Hide();
        }

        private void exitbutton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
