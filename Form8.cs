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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
      public void UpdateSalesmanDataGridView()
        {

            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM salesman";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getSalesmen = conn.CreateCommand();
                getSalesmen.CommandText = query;
                getSalesmen.CommandType = CommandType.Text;
                OracleDataReader salesmanDR = getSalesmen.ExecuteReader();
                DataTable salesmanDT = new DataTable();
                salesmanDT.Load(salesmanDR);

                dataGridView1.DataSource = salesmanDT;

                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            UpdateSalesmanDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15();

            this.Hide();
            form15.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16();

            this.Hide();
            form16.DisplaySalesmenSortedByName();
            form16.ShowDialog();
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


/// view salesman form