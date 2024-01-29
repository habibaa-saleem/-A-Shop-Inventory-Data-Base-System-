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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.UpdateDataGridView();
            this.Hide();
            form6.ShowDialog();
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
            Form22 form22 = new Form22();
            
            this.Hide();
            form22.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form23 form23 = new Form23();
            form23.UpdateDataGridViewPurchased();
            this.Hide();
            form23.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form24 form24 = new Form24();

            this.Hide();
            form24.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj;
            obj = new Form2();

            obj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form85 obj;
            obj = new Form85();

            obj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
