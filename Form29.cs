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
    public partial class Form29 : Form
    {
        public Form29()
        {
            InitializeComponent();
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Form23 form23 = new Form23();

            this.Hide();
            form23.ShowDialog();
        }


        public void searchByVendorID(int vendorID)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM purchased WHERE vendor_id = :vendorID";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getRecords = conn.CreateCommand();
                getRecords.CommandText = query;
                getRecords.CommandType = CommandType.Text;

                // Add parameter for vendor_id
                getRecords.Parameters.Add(":vendorID", OracleDbType.Int32).Value = vendorID;

                OracleDataReader recordReader = getRecords.ExecuteReader();
                DataTable recordTable = new DataTable();
                recordTable.Load(recordReader);

                dataGridView1.DataSource = recordTable;

                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vendorIDText = textBox1.Text;
            if (int.TryParse(vendorIDText, out int vendorID))
            {
                searchByVendorID(vendorID);
            }
            else
            {
                // Handle invalid input
                MessageBox.Show("Invalid vendor ID. Please enter a valid number.");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form29_Load(object sender, EventArgs e)
        {

        }
    }
}
