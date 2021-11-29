using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muradoff_Code_M_Q_S
{
    public partial class frm_callulyator : Form
    {
        public frm_callulyator()
        {
            InitializeComponent();
        }
        int reqem1, reqem2, netice;

        int asdf = 0;

        private void button16_Click(object sender, EventArgs e)
        {
            reqem2 = int.Parse(textBox1.Text);
            if (asdf == 1)
            {
                asdf = reqem1 + reqem2;
                textBox1.Text = asdf.ToString();
            }
            if (asdf == 1)
            {
                asdf = reqem1 - reqem2;
                textBox1.Text = asdf.ToString();
            }
            if (asdf == 1)
            {
                asdf = reqem1 * reqem2;
                textBox1.Text = asdf.ToString();
            }
            if (asdf == 1)
            {
                asdf = reqem1 / reqem2;
                textBox1.Text = asdf.ToString();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            reqem1 = int.Parse(textBox1.Text);
            textBox1.Text = "0";
            asdf = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            reqem1 = int.Parse(textBox1.Text);
            textBox1.Text = "0";
            asdf = 2;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            reqem1 = int.Parse(textBox1.Text);
            textBox1.Text = "0";
            asdf = 3;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            reqem1 = int.Parse(textBox1.Text);
            textBox1.Text = "0";
            asdf = 4;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf(",") < 1)
            {
                textBox1.Text = textBox1.Text + ",";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void reqemler(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text = textBox1.Text + ((Button)sender).Text;
        }
        private void frm_callulyator_Load(object sender, EventArgs e)
        {

        }
    }
}
