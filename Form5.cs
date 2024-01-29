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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "INSERT INTO salesman(first_name,last_name,email,phone,salary) VALUES (:value1, :value2, :value3, :value4, :value5)";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();
                int value;
                bool isNumeric = Int32.TryParse(this.textBox4.Text, out value);

                int value2;
                bool isNumeric2 = Int32.TryParse(this.textBox7.Text, out value2);
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("value1", textBox1.Text));
                        cmd.Parameters.Add(new OracleParameter("value2", textBox2.Text));
                        cmd.Parameters.Add(new OracleParameter("value3", textBox3.Text));
                        cmd.Parameters.Add(new OracleParameter("value4", value));
                        cmd.Parameters.Add(new OracleParameter("value5", value2));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while inserting data: " + ex.Message);
                }

                conn.Close();

            }



                this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }
    }
}
