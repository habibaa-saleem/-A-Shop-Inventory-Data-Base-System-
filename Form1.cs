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
using Oracle.ManagedDataAccess.Client;
using projectDBMS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";


            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();
                int value;
                bool isNumeric1 = Int32.TryParse(textBox6.Text, out value);
                string query1 = "SELECT category_id FROM product_categories where category_name = :value1";
                int cid = 0;
                int cid1 = 0;
                using (OracleCommand cmd2 = new OracleCommand(query1, conn))
                {
                    cmd2.Parameters.Add(new OracleParameter("value1", textBox4.Text));

                    object result1 = cmd2.ExecuteScalar();
                    if (result1 != null)
                    {
                        cid = Convert.ToInt32(result1);
                    }
                    else
                    {
                        string myquery = "INSERT INTO product_categories(category_name) VALUES (:value1)";

                        using (OracleCommand cmd1 = new OracleCommand(myquery, conn))
                        {
                            cmd1.Parameters.Add(new OracleParameter("value1", textBox4.Text));

                            int rowsAffected = cmd1.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                string query3 = "SELECT category_id FROM product_categories where category_name = :value1";
                               

                                using (OracleCommand cmd4 = new OracleCommand(query3, conn))
                                {
                                    cmd4.Parameters.Add(new OracleParameter("value1", textBox4.Text));

                                    object result2 = cmd4.ExecuteScalar();
                                    if (result2 != null)
                                    {
                                        cid1 = Convert.ToInt32(result1);
                                    }
                                }

                                    MessageBox.Show("Data inserted successfully!");
                            }
                        }


                    }
                }
                string query2 = "SELECT rack_no FROM rack where category_id = :id";
                int rackno = 0;
                using (OracleCommand cmd3 = new OracleCommand(query2, conn))
                {
                    cmd3.Parameters.Add(new OracleParameter("id", cid));

                    object result2 = cmd3.ExecuteScalar();
                    if (result2 != null)
                    {
                        rackno = Convert.ToInt32(result2);
                    }
                }
                string query = "INSERT INTO product(product_name,description,list_price,category_id,rack_no) VALUES (:value1, :value2, :value3,:cid,:rackno)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {

                    cmd.Parameters.Add(new OracleParameter("value1", textBox1.Text));
                    cmd.Parameters.Add(new OracleParameter("value2", textBox2.Text));
                    cmd.Parameters.Add(new OracleParameter("value3", value));
                    if (cid != 0)
                    cmd.Parameters.Add(new OracleParameter("cid", cid));
                    else
                        cmd.Parameters.Add(new OracleParameter("cid", cid1));
                    cmd.Parameters.Add(new OracleParameter("rackno", rackno));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Inserted failed!");
                    }
                }
                conn.Close();
            }

                this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }
    }
}

