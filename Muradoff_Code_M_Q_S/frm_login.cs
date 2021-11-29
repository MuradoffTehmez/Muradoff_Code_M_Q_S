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
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=MURADOFF-CODE\\MURADOFF_CODE;Initial Catalog=masin_qeydi;Integrated Security=True");
        bool netice;
        int otp, say;
        public void TekrarYoxla()
        {
            try
            {
                con.Open();
                SqlCommand komanda = new SqlCommand("SELECT * FROM qeydiyyat WHERE username =@usern or email=@email", con);
                komanda.Parameters.AddWithValue("@usern", textBox4.Text);
                komanda.Parameters.AddWithValue("@email", textBox5.Text);
                SqlDataReader dr = komanda.ExecuteReader();
                if (dr.Read())
                {
                    netice = false;

                }
                else
                {
                    netice = true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xeta bas verdi!! : " + ex.Message + " - " + ex.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    TekrarYoxla();
                    if (netice == true)
                    {
                        if (textBox6.Text == textBox7.Text && say >= 6 && otp <= 4)
                        {
                            con.Open();
                            SqlCommand komanda = new SqlCommand("INSERT INTO qeydiyyat (name, surname, age, username, email,password, OTPcode, adress, qeydiyyatTarixi) VALUES (@name,@surn,@age,@usern,@email,@password,@OTP,@adress, @tarix);", con);
                            komanda.Parameters.AddWithValue("@name", textBox1.Text);
                            komanda.Parameters.AddWithValue("@surn", textBox2.Text);
                            komanda.Parameters.AddWithValue("@age", Convert.ToInt32(textBox3.Text));
                            komanda.Parameters.AddWithValue("@usern", textBox4.Text);
                            komanda.Parameters.AddWithValue("@email", textBox5.Text);
                            komanda.Parameters.AddWithValue("@password", textBox6.Text);
                            komanda.Parameters.AddWithValue("@OTP", textBox8.Text);
                            komanda.Parameters.AddWithValue("@adress", textBox9.Text);
                            komanda.Parameters.AddWithValue("@tarix", textBox10.Text);
                            //komanda.Parameters.AddWithValue("@qTarix", textBox10.Text);
                            komanda.ExecuteNonQuery();
                            MessageBox.Show("Uğurla qeydiyyatdan keçdiniz!", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            temizle();
                        }
                        else
                        {
                            MessageBox.Show("Məlumatlar xetalıdır!", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bele bir istifadeci adi ve ya email adresi var!", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("TextBox bos qala bilmez!!", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xeta bas verdi!! : " + ex.Message + " - " + ex.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
          
            }
            finally
            {
                con.Close();
            }
        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox1.Focus();
            progressBar1.Value = 0;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label10.Visible = true;
            label10.Text = textBox6.Text.Length.ToString();
            say = textBox6.Text.Length;


            if (say == 0)
            {
                progressBar1.Value = 0;
                label10.Visible = false;
            }
            else if (say <= 3)
            {
                label10.BackColor = Color.Red;
                progressBar1.Value = 10;
            }
            else if (say <= 5)
            {
                label10.BackColor = Color.Red;
                progressBar1.Value = 35;
            }
            else if (say >= 6 && say <= 8)
            {
                label10.BackColor = Color.Yellow;
                progressBar1.Value = 45;
            }
            else if (say >= 12)
            {
                progressBar1.Value = 100;
            }
            else if (say >= 9)
            {
                label10.BackColor = Color.Green;
                progressBar1.Value = 75;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox6.UseSystemPasswordChar = false;
            pictureBox3.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox6.UseSystemPasswordChar = true;
            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            textBox10.Text = DateTime.Today.ToShortDateString();
        }
    }
}
