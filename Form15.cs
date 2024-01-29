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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        public void UpdateDataGridViewSearchNameSalesman(string searchName)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM salesman WHERE UPPER(first_name) LIKE '%' || UPPER(:searchName) || '%' OR UPPER(last_name) LIKE '%' || UPPER(:searchName) || '%'";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getSalesmen = conn.CreateCommand();
                getSalesmen.CommandText = query;
                getSalesmen.CommandType = CommandType.Text;

                // Add parameter for search name
                getSalesmen.Parameters.Add(":searchName", OracleDbType.Varchar2).Value = searchName.ToUpper();

                OracleDataReader salesmanDR = getSalesmen.ExecuteReader();
                DataTable salesmanDT = new DataTable();
                salesmanDT.Load(salesmanDR);

                dataGridView1.DataSource = salesmanDT;

                conn.Close();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            string searchname = textBox1.Text;
            UpdateDataGridViewSearchNameSalesman(searchname);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();

            this.Hide();
            form8.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }
    }
}
