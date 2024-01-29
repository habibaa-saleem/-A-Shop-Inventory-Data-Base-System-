using Oracle.ManagedDataAccess.Client;
using projectDBMS;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "INSERT INTO vendor(name,email,phone_number) VALUES (:value1, :value2, :value3)";
            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();
                int value;
                bool isNumeric = Int32.TryParse(this.textBox3.Text, out value);

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("value1", textBox1.Text));
                    cmd.Parameters.Add(new OracleParameter("value2", textBox2.Text));
                    cmd.Parameters.Add(new OracleParameter("value3", textBox3.Text)).Value = value;


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        string query2 = "SELECT vendor_id FROM vendor WHERE name = :value1 AND email = :value2 AND  phone_number = :value3";
                        int vendorId = 0;

                        using (OracleCommand cmd2 = new OracleCommand(query2, conn))
                        {
                            cmd2.Parameters.Add(new OracleParameter("value1", textBox1.Text));
                            cmd2.Parameters.Add(new OracleParameter("value2", textBox2.Text));
                            cmd2.Parameters.Add(new OracleParameter("value3", textBox3.Text)).Value = value;

                            object result1 = cmd2.ExecuteScalar();
                            if (result1 != null)
                            {
                                vendorId = Convert.ToInt32(result1);
                            }



                            string query3 = "INSERT INTO address_vendor(vendor_id,street_name,street_number,apartment_number,country,city) VALUES (:value1, :value5, :value6,:value7, :value8,:value9)";
                            int value1;
                            int value2;
                            bool isNumeric1 = Int32.TryParse(this.textBox5.Text, out value1);
                            bool isNumeric2 = Int32.TryParse(this.textBox7.Text, out value2);

                            using (OracleCommand cmd3 = new OracleCommand(query3, conn))
                            {
                                cmd3.Parameters.Add(new OracleParameter("value1", vendorId));
                                cmd3.Parameters.Add(new OracleParameter("value5", textBox5.Text));
                                cmd3.Parameters.Add(new OracleParameter("value6", value1));
                                cmd3.Parameters.Add(new OracleParameter("value7", value2));
                                cmd3.Parameters.Add(new OracleParameter("value8", textBox6.Text));
                                cmd3.Parameters.Add(new OracleParameter("value9", textBox8.Text));

                                int rowsAffected2 = cmd3.ExecuteNonQuery();

                                if (rowsAffected2 > 0)
                                {
                                    MessageBox.Show("Data inserted successfully!");
                                }
                            }


                        }
                    }
                }

                conn.Close();
            }
        
            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
