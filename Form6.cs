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
using WindowsFormsApp1;

namespace projectDBMS
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        // Declare a public method to update the DataGridView
       public void UpdateDataGridView()
        {

            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM product";

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



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            Form10 form10 = new Form10();
           
            this.Hide();
            form10.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();

            this.Hide();

            form11.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.DisplayProductsSortedByPrice();
            this.Hide();
            form12.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }
    }
}
