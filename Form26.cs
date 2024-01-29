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
    public partial class Form26 : Form
    {
        public Form26()
        {
            InitializeComponent();
        }
        public void searchByYear(int year)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM purchased WHERE EXTRACT(YEAR FROM purchase_date) = :year";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getPurchased = conn.CreateCommand();
                getPurchased.CommandText = query;
                getPurchased.CommandType = CommandType.Text;

                // Add parameter for year
                getPurchased.Parameters.Add(":year", OracleDbType.Int32).Value = year;

                OracleDataReader purchasedDR = getPurchased.ExecuteReader();
                DataTable purchasedDT = new DataTable();
                purchasedDT.Load(purchasedDR);

                dataGridView1.DataSource = purchasedDT;

                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string yearString = textBox1.Text;
            if (int.TryParse(yearString, out int year))
            {
                searchByYear(year);
            }
            else
            {
                // Handle invalid input or display an error message
                MessageBox.Show("Invalid year input. Please enter a valid year.");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form23 form23 = new Form23();

            this.Hide();
            form23.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
