using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDBMS
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();

            this.Hide();
            form8.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void DisplaySalesmenSortedByName()
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM salesman ORDER BY first_name ASC, last_name ASC";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getSalesmen = conn.CreateCommand();
                getSalesmen.CommandText = query;
                getSalesmen.CommandType = CommandType.Text;

                OracleDataReader salesmanDR = getSalesmen.ExecuteReader();
                DataTable salesmanDT = new DataTable();
                salesmanDT.Load(salesmanDR);

                dataGridView1.DataSource = salesmanDT;

                conn.Close();
            }
        }


        private void Form16_Load(object sender, EventArgs e)
        {

        }
    }
}
