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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();

            this.Hide();
            form6.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public void DisplayProductsSortedByPrice()
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM product ORDER BY list_price DESC";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getProducts = conn.CreateCommand();
                getProducts.CommandText = query;
                getProducts.CommandType = CommandType.Text;

                OracleDataReader productDR = getProducts.ExecuteReader();
                DataTable productDT = new DataTable();
                productDT.Load(productDR);

                dataGridView1.DataSource = productDT;

                conn.Close();
            }
        }


        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
