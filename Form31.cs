using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDBMS
{
    public partial class Form31 : Form
    {
        public Form31()
        {
            InitializeComponent();
        }
        void GetOrdersByYear(int year)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM orders WHERE EXTRACT(YEAR FROM date_of_sale) = :year";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getOrders = conn.CreateCommand();
                getOrders.CommandText = query;
                getOrders.CommandType = CommandType.Text;

                // Add parameter for year
                getOrders.Parameters.Add(":year", OracleDbType.Int32).Value = year;

                OracleDataReader orderReader = getOrders.ExecuteReader();
                DataTable orderTable = new DataTable();
                orderTable.Load(orderReader);

                dataGridView1.DataSource = orderTable;

                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string yearText = textBox1.Text;
            if (int.TryParse(yearText, out int year))
            {
                GetOrdersByYear(year);
            }
            else
            {
                // Handle invalid input
                MessageBox.Show("Invalid year. Please enter a valid number.");
            }

        }

        private void Form31_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form24 obj;
            obj = new Form24();

            obj.ShowDialog();
        }
    }
}
