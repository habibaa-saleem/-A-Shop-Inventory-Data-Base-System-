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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj;
            obj = new Form1();

            obj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 obj;
            obj = new Form3();

            obj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form6 form6 = new Form6();
            form6.UpdateDataGridView();
            this.Hide();
            form6.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 obj;
            obj = new Form18();

            obj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 obj;
            obj = new Form4();

            obj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.UpdateSalesmanDataGridView();
            this.Hide();
            form8.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.UpdateVendorDataGridView();
            this.Hide();
            form7.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        { 

            this.Hide();
            Form19 obj;
            obj = new Form19();

            obj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 obj;
            obj = new Form5();

            obj.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();

            this.Hide();
            form9.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form17 form17 = new Form17();



            this.Hide();
            form17.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }
    }
}
