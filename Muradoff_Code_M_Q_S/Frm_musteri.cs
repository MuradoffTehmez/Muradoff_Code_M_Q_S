using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Muradoff_Code_M_Q_S
{
    public partial class Frm_musteri : Form
    {
        afto_kira afto = new afto_kira();
        public Frm_musteri()
        {
            InitializeComponent();
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
                MessageBox.Show("Çıkış yapılmadı", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("qeydiyatdan kecilsin  ", "DİQQƏT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialog == DialogResult.Yes)
            {
                string emr = "insert into musteri_qey(soyadi,adi,email,cinsi,verendasliq,dag_tarix,vesiqe,qan,ves_verilme,ves_son_is,tarix) values(@soyadi,@adi,@email,@cinsi,@verendasliq,@dag_tarix,@vesiqe,@qan,@ves_verilme,@ves_son_is,@tarix)";
                SqlCommand kom = new SqlCommand();
                kom.Parameters.AddWithValue("@soyadi", txt_soyad.Text);
                kom.Parameters.AddWithValue("@adi", txt_ad.Text);
                kom.Parameters.AddWithValue("@email", txt_email.Text);
                kom.Parameters.AddWithValue("@cinsi", comboBox1.Text);
                kom.Parameters.AddWithValue("@verendasliq", tct_vetendas.Text);
                kom.Parameters.AddWithValue("@dag_tarix", txt_dogum_tax.Text);
                kom.Parameters.AddWithValue("@vesiqe", txt_vesiqe_nom.Text);
                kom.Parameters.AddWithValue("@qan", comboBox2.Text);
                kom.Parameters.AddWithValue("@ves_verilme", txt_vesiqenin_verilmr_tax.Text);
                kom.Parameters.AddWithValue("@ves_son_is", txt_vesuqenun_son_istifade_tarixi.Text);
                kom.Parameters.AddWithValue("@tarix", Convert.ToDateTime(DateTime.Today.ToShortDateString()));
                afto.eleve_sil_deyis(kom,emr);
                MessageBox.Show("Siz Uğurla qeydiyatdan keçdiniz", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                //foreach (Control item in Controls) if (item is ComboBox) item.
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Qeydiyyat olmadi ! ! ", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Frm_musteri_Load(object sender, EventArgs e)
        {
            label12.Text = DateTime.Today.ToShortDateString();
        }
    }
}
