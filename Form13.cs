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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            Form7 form7 = new Form7();

            this.Hide();
            form7.ShowDialog();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void UpdateDataGridViewSearchNameVendor(string searchVendor)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM Vendor WHERE UPPER(name) LIKE '%' || UPPER(:searchVendor) || '%'";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getVendors = conn.CreateCommand();
                getVendors.CommandText = query;
                getVendors.CommandType = CommandType.Text;

                // Add parameter for search vendor name
                getVendors.Parameters.Add(":searchVendor", OracleDbType.Varchar2).Value = searchVendor.ToUpper();

                OracleDataReader vendorDR = getVendors.ExecuteReader();
                DataTable vendorDT = new DataTable();
                vendorDT.Load(vendorDR);

                dataGridView1.DataSource = vendorDT;

                conn.Close();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

            string searchname = textBox1.Text;
            UpdateDataGridViewSearchNameVendor(searchname);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
