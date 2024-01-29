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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form6 form6 = new Form6();

            this.Hide();
            form6.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void DisplayProductsByCategory(string categoryName)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = @"SELECT p.* 
                     FROM product p 
                     INNER JOIN product_categories pc ON p.category_id = pc.category_id
                     WHERE UPPER(pc.category_name) = UPPER(:categoryName)
                     ORDER BY p.list_price DESC";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getProducts = conn.CreateCommand();
                getProducts.CommandText = query;
                getProducts.CommandType = CommandType.Text;

                // Add parameter for category name
                getProducts.Parameters.Add(":categoryName", OracleDbType.Varchar2).Value = categoryName.ToUpper();

                OracleDataReader productDR = getProducts.ExecuteReader();
                DataTable productDT = new DataTable();
                productDT.Load(productDR);

                dataGridView1.DataSource = productDT;

                conn.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string searchname = textBox1.Text;
            DisplayProductsByCategory(searchname);
        }
    }
}
