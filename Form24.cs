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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form31 obj;
            obj = new Form31();

            obj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 obj;
            obj = new Form21();

            obj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form32 obj;
            obj = new Form32();

            obj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form33 obj;
            obj = new Form33();

            obj.ShowDialog();
        }
        public void UpdateDataGridViewOrders()
        {
            string connString = "DATA SOURCE =localhost:1521/xe ;  USER ID =FINAL;PASSWORD = macBook96";
            string query = "SELECT * FROM orders";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getOrders = conn.CreateCommand();
                getOrders.CommandText = query;
                getOrders.CommandType = CommandType.Text;

                OracleDataReader ordersDR = getOrders.ExecuteReader();
                DataTable ordersDT = new DataTable();
                ordersDT.Load(ordersDR);

                dataGridView1.DataSource = ordersDT;

                conn.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form34 obj;
            obj = new Form34();

            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form35 obj;
            obj = new Form35();

            obj.ShowDialog();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            UpdateDataGridViewOrders();
        }
    }
}
