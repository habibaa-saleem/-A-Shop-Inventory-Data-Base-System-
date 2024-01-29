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
    public partial class Form33 : Form
    {
        public Form33()
        {
            InitializeComponent();
        }

        private void Form33_Load(object sender, EventArgs e)
        {

        }
        public void GetOrdersByMonth(int month)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM orders WHERE EXTRACT(MONTH FROM date_of_sale) = :month";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getOrders = conn.CreateCommand();
                getOrders.CommandText = query;
                getOrders.CommandType = CommandType.Text;

                // Add parameter for month
                getOrders.Parameters.Add(":month", OracleDbType.Int32).Value = month;

                OracleDataReader orderReader = getOrders.ExecuteReader();
                DataTable orderTable = new DataTable();
                orderTable.Load(orderReader);

                dataGridView1.DataSource = orderTable;

                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string monthText = textBox1.Text;
            if (int.TryParse(monthText, out int month))
            {
                GetOrdersByMonth(month);
            }
            else
            {
                // Handle invalid input
                MessageBox.Show("Invalid month. Please enter a valid number.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form24 obj;
            obj = new Form24();

            obj.ShowDialog();
        }
    }
}
