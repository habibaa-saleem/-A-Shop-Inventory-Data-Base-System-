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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }
        public void UpdateDataGridViewPurchased()
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT * FROM purchased";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                OracleCommand getPurchased = conn.CreateCommand();
                getPurchased.CommandText = query;
                getPurchased.CommandType = CommandType.Text;

                OracleDataReader purchasedDR = getPurchased.ExecuteReader();
                DataTable purchasedDT = new DataTable();
                purchasedDT.Load(purchasedDR);

                dataGridView1.DataSource = purchasedDT;

                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form26 form26 = new Form26();
           
            this.Hide();
            form26.ShowDialog();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            UpdateDataGridViewPurchased();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form36 form36 = new Form36();

            this.Hide();
            form36.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form28 form28 = new Form28();

            this.Hide();
            form28.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form29 form29 = new Form29();

            this.Hide();
            form29.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 obj;
            obj = new Form21();

            obj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form30 obj;
            obj = new Form30();

            obj.ShowDialog();

        }
    }
}
