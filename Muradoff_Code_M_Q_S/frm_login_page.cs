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
    public partial class frm_login_page : Form
    {
        public frm_login_page()
        {
            InitializeComponent();
        }
        public static string ad;

        SqlConnection con = new SqlConnection("Data Source=MURADOFF-CODE\\MURADOFF_CODE;Initial Catalog=masin_qeydi;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ad = textBox1.Text;
                con.Open();
                SqlCommand komanda = new SqlCommand("SELECT * FROM qeydiyyat WHERE username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);

                SqlDataReader dr = komanda.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Giriş uğurludur!", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Frm_ana_sehife a = new Frm_ana_sehife();
                    a.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş xetalıdır!", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("XETA bas verdi!! : " + ex.Message + " - " + ex.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox5.Visible = true;
            pictureBox2.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox5.Visible = false;
            pictureBox2.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_login_forget forget = new frm_login_forget();
            forget.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_login frm_Login = new frm_login();
            frm_Login.ShowDialog();
        }

        private void frm_login_page_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            praqramdan_cix();
        }
        public void praqramdan_cix()
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Programdan çıxış edilsin ", "DİQQƏT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Çıkış yapılmadı", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
