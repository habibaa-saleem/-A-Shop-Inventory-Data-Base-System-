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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
       public void UpdateVendorDataGridView()
        {

            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM vendor";

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

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();

            this.Hide();
            form13.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();

            this.Hide();
            form14.DisplayVendorSortedByName();
            form14.ShowDialog();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            UpdateVendorDataGridView();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }
    }
}


//// view vendors form