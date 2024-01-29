using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }
        string selectedValue = null;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "DATA SOURCE =localhost:1521/xe ; USER ID= fastuser;PASSWORD=fastnuces";

            string query2 = "SELECT quantity from inventories where barcodeid = :value";



            using (OracleConnection conn = new OracleConnection(connString))
            {

                conn.Open();
                int value;

                bool isNumeric = Int32.TryParse(this.textBox1.Text, out value);
                int value2;
                bool isNumeric2 = Int32.TryParse(this.textBox3.Text, out value2);
                int value3;
                bool isNumeric3 = Int32.TryParse(this.textBox5.Text, out value3);
                using (OracleCommand cmd2 = new OracleCommand(query2, conn))
                {
                    int value4;
                    bool isNumeric4 = Int32.TryParse(this.textBox2.Text, out value4);
                    int value5;
                    bool isNumeric5 = Int32.TryParse(this.textBox4.Text, out value5);

                    int in_quantity = 0;
                    cmd2.Parameters.Add(new OracleParameter("value", value));
                    object result1 = cmd2.ExecuteScalar();

                    if (result1 != null)
                    {


                        in_quantity = Convert.ToInt32(result1);
                        if ((in_quantity - value4) > 0)
                        {
                            string sql = "UPDATE inventories SET quantity = quantity- :value4 WHERE barcodeid = :value";
                            try
                            {
                                using (OracleCommand cmd4 = new OracleCommand(sql, conn))
                                {
                                    cmd4.Parameters.Add(new OracleParameter("value4", value4));
                                    cmd4.Parameters.Add(new OracleParameter("value", value));


                                    int rowsAffected3 = cmd4.ExecuteNonQuery();

                                    if (rowsAffected3 > 0)
                                    {
                                        MessageBox.Show("inventories updated!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("An error occured while updating inventories ");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occured while updating inventories " + ex.Message);
                            }
                            string query = "INSERT INTO orders(barcodeid,customer_id,salesman_id,status) VALUES (:value1, :value2, :value3, :value4) RETURNING order_id INTO :id";

                            try
                            {
                                using (OracleCommand cmd = new OracleCommand(query, conn))
                                {
                                    cmd.Parameters.Add(new OracleParameter("value1", value));
                                    cmd.Parameters.Add(new OracleParameter("value2", value2));
                                    cmd.Parameters.Add(new OracleParameter("value3", value3));
                                    cmd.Parameters.Add(new OracleParameter("value4", selectedValue));
                                    OracleParameter parameter = new OracleParameter(":id", OracleDbType.Double);
                                    parameter.Direction = ParameterDirection.Output;
                                    cmd.Parameters.Add(parameter);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {

                                        double insertedId = ((OracleDecimal)cmd.Parameters[":id"].Value).ToDouble();
                                        try
                                        {
                                            string query1 = "INSERT INTO order_items(order_id,barcodeid,quantity, unit_price) VALUES (:value1, :value2, :value3, :value4) ";


                                            using (OracleCommand cmd3 = new OracleCommand(query1, conn))
                                            {
                                                cmd3.Parameters.Add(new OracleParameter("value1", insertedId));
                                                cmd3.Parameters.Add(new OracleParameter("value2", value));
                                                cmd3.Parameters.Add(new OracleParameter("value3", value4));
                                                cmd3.Parameters.Add(new OracleParameter("value4", value5));
                                                int rowsAffected1 = cmd3.ExecuteNonQuery();

                                                if (rowsAffected1 > 0)
                                                    MessageBox.Show("Order placed!");
                                            }

                                        }

                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("An error occured while inserting data " + ex.Message);
                                        }


                                    }

                                    else
                                    {
                                        MessageBox.Show("Your inventory does not have this item!");
                                    }



                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occured while inserting data " + ex.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("you do not have enough items in your inventory");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Your inventory does not have this item!");
                    }


                }



                conn.Close();
            }

            this.Hide();
            Form2 obj;
            obj = new Form2();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
                selectedValue = radioButton.Text.ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
                selectedValue = radioButton.Text.ToString();
            }
        }
    }
}
