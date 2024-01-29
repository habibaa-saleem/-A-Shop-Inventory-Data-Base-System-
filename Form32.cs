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
    public partial class Form32 : Form
    {
        public Form32()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form24 obj;
            obj = new Form24();

            obj.ShowDialog();
        }
        public void GetOrdersByDay(string day)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM orders WHERE TO_CHAR(date_of_sale, 'DY', 'NLS_DATE_LANGUAGE=ENGLISH') = :day";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getOrders = conn.CreateCommand();
                getOrders.CommandText = query;
                getOrders.CommandType = CommandType.Text;

                // Add parameter for day
                getOrders.Parameters.Add(":day", OracleDbType.Varchar2).Value = day.ToUpper();

                OracleDataReader orderReader = getOrders.ExecuteReader();
                DataTable orderTable = new DataTable();
                orderTable.Load(orderReader);

                dataGridView1.DataSource = orderTable;

                conn.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string day = textBox1.Text;
            GetOrdersByDay(day);

        }
    }
}
