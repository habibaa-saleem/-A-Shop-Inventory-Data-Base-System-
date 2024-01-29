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
    public partial class Form34 : Form
    {
        public Form34()
        {
            InitializeComponent();
        }

        private void Form34_Load(object sender, EventArgs e)
        {

        }
        public void GetOrderByID(int orderID)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM orders WHERE order_id = :orderID";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getOrders = conn.CreateCommand();
                getOrders.CommandText = query;
                getOrders.CommandType = CommandType.Text;

                // Add parameter for order_id
                getOrders.Parameters.Add(":orderID", OracleDbType.Int32).Value = orderID;

                OracleDataReader orderReader = getOrders.ExecuteReader();
                DataTable orderTable = new DataTable();
                orderTable.Load(orderReader);

                dataGridView1.DataSource = orderTable;

                conn.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string orderIDText = textBox1.Text;
            if (int.TryParse(orderIDText, out int orderID))
            {
                GetOrderByID(orderID);
            }
            else
            {
                // Handle invalid input
                MessageBox.Show("Invalid order ID. Please enter a valid number.");
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
