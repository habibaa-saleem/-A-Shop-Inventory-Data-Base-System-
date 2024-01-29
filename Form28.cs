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
    public partial class Form28 : Form
    {
        public Form28()
        {
            InitializeComponent();
        }
        public void searchByDay(string day)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM purchased WHERE TO_CHAR(purchase_date, 'DY', 'NLS_DATE_LANGUAGE=ENGLISH') = :day";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getRecords = conn.CreateCommand();
                getRecords.CommandText = query;
                getRecords.CommandType = CommandType.Text;

                // Add parameter for day
                getRecords.Parameters.Add(":day", OracleDbType.Varchar2).Value = day.ToUpper();

                OracleDataReader recordReader = getRecords.ExecuteReader();
                DataTable recordTable = new DataTable();
                recordTable.Load(recordReader);

                dataGridView1.DataSource = recordTable;

                conn.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form23 form23 = new Form23();

            this.Hide();
            form23.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string day = textBox1.Text;
            searchByDay( day);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
