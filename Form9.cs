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
using projectDBMS;
using WindowsFormsApp1;

namespace projectDBMS
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string passworddummy = textBox2.Text;
            string id = textBox3.Text;


            string connectionString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";
            string query = "SELECT COUNT(*) FROM all_users WHERE USERNAME = :username  ";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("username", username));

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            //string lastTwoCharacters = passworddummy.Substring(passworddummy.Length - 2);

                            this.Hide();
                            Form2 obj;
                            obj = new Form2();
                            obj.ShowDialog();
                            
                          
                        }
                        else
                        {
                            MessageBox.Show("User not found");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during connection or database operations
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
