using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muradoff_Code_M_Q_S
{
    public partial class frm_login_forget : Form
    {
        public frm_login_forget()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=MURADOFF-CODE\\MURADOFF_CODE;Initial Catalog=masin_qeydi;Integrated Security=True");

        public void TekrarYoxla()
        {
            try
            {
                con.Open();
                SqlCommand komanda = new SqlCommand("SELECT * FROM qeydiyyat WHERE email =@email and OTPcode=@OTP", con);
                komanda.Parameters.AddWithValue("@email", textBox1.Text);
                komanda.Parameters.AddWithValue("@OTP", textBox2.Text);
                SqlDataReader dr = komanda.ExecuteReader();
                if (dr.Read())
                {
                    netice = true;

                }
                else
                {
                    netice = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("XETA bas verdi!! : " + ex);
            }
            finally
            {
                con.Close();
            }
        }
        bool netice;
        private void button1_Click(object sender, EventArgs e)
        {
            TekrarYoxla();
            if (netice == true)
            {
                try
                {
                    if (textBox3.Text == textBox4.Text)
                    {
                        con.Open();
                        SqlCommand komanda = new SqlCommand("UPDATE qeydiyyat SET password=@new where OTPcode=@OTP and email=@email", con);
                        komanda.Parameters.AddWithValue("@email", textBox1.Text);
                        komanda.Parameters.AddWithValue("@OTP", textBox2.Text);
                        komanda.Parameters.AddWithValue("@new", textBox3.Text);
                        komanda.ExecuteNonQuery();
                        //con.Close();
                        MessageBox.Show("Uğurla password deyişdirildi!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Məlumatlar xetalıdır!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xeta bas verdi!! : " + ex);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Bele istifaci yoxdur!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
