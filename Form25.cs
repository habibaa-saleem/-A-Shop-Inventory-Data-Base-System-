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
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
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


            using (OracleConnection conn = new OracleConnection(connString))
            {
                string query = "INSERT into purchased(barcodeid,vendor_id,total_cost,paid) VALUES(:value1,:value2, :value3,:value4)";
                try
                {
                    int value1;
                    int value2;
                    int value3;
                    int value4;
                    bool isNumeric1 = Int32.TryParse(this.textBox4.Text, out value1);
                    bool isNumeric2 = Int32.TryParse(this.textBox1.Text, out value2);
                    bool isNumeric3 = Int32.TryParse(this.textBox7.Text, out value3);
                    bool isNumeric4 = Int32.TryParse(this.textBox3.Text, out value4);
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        conn.Open();

                        cmd.Parameters.Add(new OracleParameter("value1", value1));
                        cmd.Parameters.Add(new OracleParameter("value2", value2));
                        cmd.Parameters.Add(new OracleParameter("value3", value3));
                        cmd.Parameters.Add(new OracleParameter("value3", value4));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Purchase successful!");
                        }

                        string query1 = "INSERT into inventories(barcodeid,safety_stock_level,lead_time,quantity) VALUES(:value1,:value2, :value3,:value4)";
                        try
                        {
                            using (OracleCommand cmd1 = new OracleCommand(query1, conn))
                            {
                                bool isNumeric5 = Int32.TryParse(this.textBox6.Text, out value2);
                                bool isNumeric6 = Int32.TryParse(this.textBox5.Text, out value3);
                                bool isNumeric7 = Int32.TryParse(this.textBox2.Text, out value4);


                                cmd1.Parameters.Add(new OracleParameter("value1", value1));
                                cmd1.Parameters.Add(new OracleParameter("value2", value2));
                                cmd1.Parameters.Add(new OracleParameter("value3", value3));
                                cmd1.Parameters.Add(new OracleParameter("value4", value4));

                                int rowsAffected1 = cmd1.ExecuteNonQuery();
                                if (rowsAffected1 > 0)
                                {
                                    MessageBox.Show("inventories updated!");
                                }


                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occured while inserting data " + ex.Message);

                        }
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while inserting data " + ex.Message);

                }
                finally
                {

                    conn.Close();
                }
            }
            this.Hide();
            Form2 obj;
            obj = new Form2();
            obj.ShowDialog();
        }

        private void Form25_Load(object sender, EventArgs e)
        {

        }
    }
}
