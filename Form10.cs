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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
        public void UpdateDataGridViewSearchName(string searchName)
        {

            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM product WHERE UPPER(product_name) LIKE '%' || UPPER(:searchName) || '%'";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getProducts = conn.CreateCommand();
                getProducts.CommandText = query;
                getProducts.CommandType = CommandType.Text;

                // Add parameter for search name
                getProducts.Parameters.Add(":searchName", OracleDbType.Varchar2).Value = searchName.ToUpper();

                OracleDataReader productDR = getProducts.ExecuteReader();
                DataTable productDT = new DataTable();
                productDT.Load(productDR);

                dataGridView1.DataSource = productDT;

                conn.Close();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchname = textBox1.Text;
            UpdateDataGridViewSearchName(searchname);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form6 form6 = new Form6();

            this.Hide();
            form6.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}


// show the products by searching by name form