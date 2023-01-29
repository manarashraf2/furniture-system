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

namespace Connected
{
    public partial class Connected : Form
    {
        string ordb = "Data source =ORCL; User Id =scott; Password = tiger;";
        OracleConnection Conn;

        public Connected()
        {
            InitializeComponent();
        }

        private void Connected_Load(object sender, EventArgs e)
        {
            Conn = new OracleConnection(ordb);
            Conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = Conn;
            cmd.CommandText = "Select ItemID from Items";       
            
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Cmb_itemID.Items.Add(dr[0]);
               
            }
            dr.Close();
        }

        private void CmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = Conn;
            cmd2.CommandText = "Select Item_Name, ItemCategory, ItemPrice, Item_State," +
            "Item_Description, Production_Country, Item_Seller from Items where ItemID = :id";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id", Cmb_itemID.SelectedItem.ToString());
            OracleDataReader dr = cmd2.ExecuteReader();

            if (dr.Read())
            {
                Item_Name.Text = dr[0].ToString();
                Item_Category.Text = dr[1].ToString();
                Item_price.Text = dr[2].ToString();
                Item_Availability.Text = dr[3].ToString();
                Item_Description.Text = dr[4].ToString();
                Production_Country.Text = dr[5].ToString();
                Item_Seller.Text = dr[6].ToString();
            }

            dr.Close();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            OracleCommand cmd3 = new OracleCommand();
            cmd3.Connection = Conn;
            cmd3.CommandText = "insert into Items values (:id, :name, :Category, :Price, :State, :Description, :PC, :Seller)";
            cmd3.CommandType = CommandType.Text;
            cmd3.Parameters.Add("id", Cmb_itemID.Text);
            cmd3.Parameters.Add("name", Item_Name.Text);
            cmd3.Parameters.Add("category", Item_Category.Text);
            cmd3.Parameters.Add("price", Item_price.Text);
            cmd3.Parameters.Add("state", Item_Availability.Text);
            cmd3.Parameters.Add("Description", Item_Description.Text);
            cmd3.Parameters.Add("pc", Production_Country.Text);
            cmd3.Parameters.Add("seller", Item_Seller.Text);
            int r = cmd3.ExecuteNonQuery();

            if (r != 0)
            {
                Cmb_itemID.Items.Add(Cmb_itemID.Text);
                MessageBox.Show("NEW ITEM IS ADDED");
            }
         
        }

        private void Show_Prices_Click(object sender, EventArgs e)
        {
            OracleCommand cmd4 = new OracleCommand();
            cmd4.Connection = Conn;
            cmd4.CommandText = "GETITEMPRICE";
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.Add("price", OracleDbType.Int32, ParameterDirection.Output);
            int p = cmd4.ExecuteNonQuery();
            if (p != 0)
            {
               // MessageBox.Show("Max Item price is " + Convert.ToInt32(cmd4.Parameters["price"].Value.ToString()));
                Max_price.Text =(cmd4.Parameters["price"].Value.ToString());
            }

        }

        private void Cmb_Item_State_SelectedIndexChanged(object sender, EventArgs e)
        {

            OracleCommand cmd5 = new OracleCommand();
            cmd5.Connection = Conn;
            cmd5.CommandText = "GETITEMID ";
            cmd5.CommandType = CommandType.StoredProcedure;
            cmd5.Parameters.Add("state", Cmb_Item_State.SelectedItem.ToString());
            cmd5.Parameters.Add("id", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader dr = cmd5.ExecuteReader();

            while (dr.Read())
            {
                Cmb_ItemID2.Items.Add(dr[0]);
            }

            dr.Close();
        }
        private void Connected_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Dispose();
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
