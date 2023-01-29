using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace WindowsFormsApp3
{
    public partial class addtocart : Form
    {
        OracleDataAdapter adapter;
        //OracleCommandBuilder builder;
        DataSet ds;
        public addtocart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=orcl;User Id=scott;Password=tiger;";
            string comstr = @"select ca.CUSTOMERID,ITEMID, CART_QUANTITY
                              from CART ca ,CUSTOMER cus
                              where ca.CUSTOMERID= cus.CUSTOMERID
                              AND ca.CUSTOMERID=:id";


            adapter = new OracleDataAdapter(comstr, constr);
            adapter.SelectCommand.Parameters.Add("id", cusnametextBox.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];

        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
            ds.Tables[0].Columns["ITEMID"].Unique = true;
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("updated successfully");
        }

        private void addtocart_Load(object sender, EventArgs e)
        {

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

        private void cusnametextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
