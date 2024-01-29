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

namespace projectDBMS
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";

            using (OracleConnection conn = new OracleConnection(connString))
            {
                string query1 = "SELECT COUNT(*) FROM product_categories where category_name = :value1";


                conn.Open();

                using (OracleCommand cmd1 = new OracleCommand(query1, conn))
                {
                    cmd1.Parameters.Add(new OracleParameter("value1", textBox3.Text));
                    object result = cmd1.ExecuteScalar();
                    if (result != null)
                    {
                        int categoryCount = Convert.ToInt32(result);
                        if (categoryCount == 0)
                        {
                            string query2 = "INSERT INTO product_categories(category_name) VALUES (:value1)";
                            using (OracleCommand cmd2 = new OracleCommand(query2, conn))
                            {
                                cmd2.Parameters.Add(new OracleParameter("value1", textBox3.Text));
                                int rowsAffected = cmd2.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data inserted successfully!");
                                }
                            }
                        }
                    }
                    string query = "SELECT category_id FROM product_categories where category_name = :value1";
                    int cid = 0;
                    using (OracleCommand cmd2 = new OracleCommand(query, conn))
                    {
                        cmd2.Parameters.Add(new OracleParameter("value1", textBox3.Text));
                        object result1 = cmd2.ExecuteScalar();
                        if (result1 != null)
                        {
                            cid = Convert.ToInt32(result1);
                        }
                    }

                    string query3 = "INSERT INTO rack(rack_no,description,category_id) VALUES (:value2,:value3,:cid)";
                    using (OracleCommand cmd = new OracleCommand(query3, conn))
                    {
                        int value;
                        bool isNumeric = Int32.TryParse(textBox1.Text, out value);
                        cmd.Parameters.Add(new OracleParameter("value2", value));
                        cmd.Parameters.Add(new OracleParameter("value3", textBox2.Text));
                        cmd.Parameters.Add(new OracleParameter("cid", cid));
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully!");
                        }
                    }

                    conn.Close();
                }
            }
            this.Hide();
            Form20 obj;
            obj = new Form20();

            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form20 obj;
            obj = new Form20();

            obj.ShowDialog();
        }
    }
}
