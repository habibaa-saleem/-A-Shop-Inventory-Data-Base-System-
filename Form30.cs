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
    public partial class Form30 : Form
    {
        public Form30()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void searchByBillID(int billID)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM purchased WHERE bill_id = :billID";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getRecords = conn.CreateCommand();
                getRecords.CommandText = query;
                getRecords.CommandType = CommandType.Text;

                // Add parameter for bill_id
                getRecords.Parameters.Add(":billID", OracleDbType.Int32).Value = billID;

                OracleDataReader recordReader = getRecords.ExecuteReader();
                DataTable recordTable = new DataTable();
                recordTable.Load(recordReader);

                dataGridView1.DataSource = recordTable;

                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string billIDText = textBox1.Text;
            if (int.TryParse(billIDText, out int billID))
            {
                searchByBillID(billID);
            }
            else
            {
                // Handle invalid input
                MessageBox.Show("Invalid bill ID. Please enter a valid number.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form23 obj;
            obj = new Form23();

            obj.ShowDialog();
        }
    }
}
