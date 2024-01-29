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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();

            this.Hide();
            form7.ShowDialog();
        }
        public void DisplayVendorSortedByName()
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM Vendor ORDER BY name ASC";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getVendors = conn.CreateCommand();
                getVendors.CommandText = query;
                getVendors.CommandType = CommandType.Text;

                OracleDataReader vendorDR = getVendors.ExecuteReader();
                DataTable vendorDT = new DataTable();
                vendorDT.Load(vendorDR);

                dataGridView1.DataSource = vendorDT;

                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            DisplayVendorSortedByName();

        }
    }
}
