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
    public partial class frm_masin_siyahisi : Form
    {
        afto_kira qaqili = new afto_kira();
        public frm_masin_siyahisi()
        {
            InitializeComponent();
        }
        bool netice;
        private void DataGridView(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(59, 53, 57);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Green;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(42, 44, 46);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;        
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_masin_siyahisi_Load(object sender, EventArgs e)
        {
            error_goster();
            goster_masin_melumatlarini();
            try
            {
                comboBox1.SelectedIndex = 0;
                goster_masin_melumatlarini();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xeta bas verdi!! : " + ex.Message + " - " + ex.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            DataGridView(dataGridView1);
            
        }

        private void error_goster()
        {
            errorProvider1.BlinkRate = 250;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            txt_qeydiyat_id.MaxLength = 5;
            txt_kimlik_ide.MaxLength = 10;
            txt_afto_at_gucu.MaxLength = 5;
            txt_afto_qiymeti.MaxLength = 6;
            txt_afto_kira_qiymeti.MaxLength = 6;
        }

        private void goster_masin_melumatlarini()
        {
            string emr = "select * from aftos";
            SqlDataAdapter adap = new SqlDataAdapter();
            dataGridView1.DataSource = qaqili.list(adap, emr);
            
        }
        private void temizle()
        {
            combo_marka.Text = "";
            combo_afto_dozasi.Text = "";
            combo_afto_model_nov.Text = "";
            combo_afto_skorus_paylayici.Text = "";
            combo_afto_yanacaq_nov.Text = "";
            combo_seriyasi.Text = "";
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            pictureBox2.ImageLocation = "";
        }// deyisdir nomreye ve kimliye gore axtarmaq
        private void btn_qeydiyyat_et_Click(object sender, EventArgs e)
        {
            string emr = "update aftos set marka=@marka,afto_nov=@afto_nov,seriysa_nov=@seriysa_nov,cixis_ili=@cixis_ili,modeli=@modeli,rengi=@rengi,yanacaq_nov=@yanacaq_nov,dozasi_=@dozasi_,sureti=@sureti,qiymeti=@qiymeti,kira_qiymeti=@kira_qiymeti,skorus_payla=@skorus_payla,at_gucu=@at_gucu,tarix=@tarix where plaka= '" + txt_plaka.Text + "'";
            SqlCommand votka = new SqlCommand();
        //  votka.Parameters.AddWithValue("@id", txt_qeydiyat_id.Text);
       //   votka.Parameters.AddWithValue("@plaka", txt_plaka.Text);
        //  votka.Parameters.AddWithValue("@sehsiyet_id", txt_kimlik_ide.Text);
            votka.Parameters.AddWithValue("@marka", combo_marka.Text);
            votka.Parameters.AddWithValue("@afto_nov", combo_afto_model_nov.Text);
            votka.Parameters.AddWithValue("@seriysa_nov", combo_seriyasi.Text);
            votka.Parameters.AddWithValue("@cixis_ili", Convert.ToDateTime(txt_afto_cixis_ili.Text));
            votka.Parameters.AddWithValue("@modeli", txt_model.Text);
            votka.Parameters.AddWithValue("@rengi", txt_rengi.Text);
        //  votka.Parameters.AddWithValue("@afto_nov",.Text);
            votka.Parameters.AddWithValue("@yanacaq_nov", combo_afto_yanacaq_nov.Text);
            votka.Parameters.AddWithValue("@dozasi_", combo_afto_dozasi.Text);
            votka.Parameters.AddWithValue("@sureti", txt_sureti.Text);
            votka.Parameters.AddWithValue("@qiymeti", txt_afto_qiymeti.Text);
            votka.Parameters.AddWithValue("@kira_qiymeti", int.Parse(txt_afto_kira_qiymeti.Text));
            votka.Parameters.AddWithValue("@skorus_payla", combo_afto_skorus_paylayici.Text);
            votka.Parameters.AddWithValue("@at_gucu", txt_afto_at_gucu.Text);
        //  votka.Parameters.AddWithValue("@sekil_", Convert.ToString(pictureBox1.ImageLocation.ToString()));
        //  votka.Parameters.AddWithValue("@veziyeti", "BOS");
            votka.Parameters.AddWithValue("@tarix", Convert.ToDateTime(DateTime.Today.ToShortDateString()));
            qaqili.eleve_sil_deyis(votka, emr);
            goster_masin_melumatlarini();
            temizleles();
           
        }
        private void temizleles()
        {
            //combo_marka.Items.Clear();
           // combo_afto_dozasi.Items.Clear();
           // combo_afto_model_nov.Items.Clear();
           // combo_afto_skorus_paylayici.Items.Clear();
        //    combo_afto_yanacaq_nov.Items.Clear();
          //  combo_seriyasi.Items.Clear();
            //foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            pictureBox1.ImageLocation = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
             DataGridViewRow viewRow = dataGridView1.CurrentRow;
            string emr5 = "delete from musteri_qey where vesiqe '" + viewRow.Cells[6].Value.ToString() + "'";
            SqlCommand sqlCommand = new SqlCommand();
            afto.eleve_sil_deyis(sqlCommand, emr5);
            MessageBox.Show("Siz Uğurla melumatlari Sildiniz", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            goster_list();
            
            */
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow votka = dataGridView1.CurrentRow;
            txt_qeydiyat_id.Text = votka.Cells["id"].Value.ToString();
            txt_plaka.Text = votka.Cells["plaka"].Value.ToString();
            txt_kimlik_ide.Text = votka.Cells["sehsiyet_id"].Value.ToString();
            combo_marka.Text = votka.Cells["marka"].Value.ToString();
            combo_afto_model_nov.Text = votka.Cells["afto_nov"].Value.ToString();
            combo_seriyasi.Text = votka.Cells["seriysa_nov"].Value.ToString();
            txt_afto_cixis_ili.Text = votka.Cells["cixis_ili"].Value.ToString();
            txt_model.Text = votka.Cells["modeli"].Value.ToString();
            txt_rengi.Text = votka.Cells["rengi"].Value.ToString();
            combo_afto_yanacaq_nov.Text = votka.Cells["yanacaq_nov"].Value.ToString();
            combo_afto_dozasi.Text = votka.Cells["dozasi_"].Value.ToString();
            txt_sureti.Text = votka.Cells["sureti"].Value.ToString();
            txt_afto_qiymeti.Text = votka.Cells["qiymeti"].Value.ToString();
            txt_afto_kira_qiymeti.Text = votka.Cells["kira_qiymeti"].Value.ToString();
            combo_afto_skorus_paylayici.Text = votka.Cells["skorus_payla"].Value.ToString();
            txt_afto_at_gucu.Text = votka.Cells["at_gucu"].Value.ToString();
            pictureBox2.ImageLocation = votka.Cells["sekil_"].Value.ToString();
            txt_tarix_text.Text = votka.Cells["tarix"].Value.ToString();
           
        }

        private void pcbox_sekil_deyis_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        private void txt_sureti_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_qeydiyat_id_TextChanged(object sender, EventArgs e)
        {
            if (txt_qeydiyat_id.Text.Length<5 || txt_qeydiyat_id.Text.Length>5)
            {
                errorProvider1.SetError(txt_qeydiyat_id, "5 den ola bilmez diresme");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txt_kimlik_ide_TextChanged(object sender, EventArgs e)
        {
            if (txt_kimlik_ide.Text.Length < 8 || txt_qeydiyat_id.Text.Length > 8)
            {
                errorProvider1.SetError(txt_qeydiyat_id, "8 olmaliddi");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txt_model_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)||e.KeyChar==8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_rengi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_afto_at_gucu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsLetter(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_kimlik_ide_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_afto_at_gucu_TextChanged(object sender, EventArgs e)
        {
            if (txt_afto_at_gucu.Text.Length < 4 || txt_qeydiyat_id.Text.Length > 4 )
            {
                errorProvider1.SetError(txt_qeydiyat_id, "4 olmaliddi");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DataGridViewRow eseb = dataGridView1.CurrentRow;
            string emr = "delete from aftos where plaka = '" + txt_plaka.Text + "'";
            SqlCommand komanda = new SqlCommand();
            qaqili.eleve_sil_deyis(komanda,emr);
            goster_masin_melumatlarini();
            temizleles();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    goster_masin_melumatlarini();
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    string emr = "select * from aftos where veziyeti ='BOS'";
                    SqlDataAdapter adap = new SqlDataAdapter();
                    dataGridView1.DataSource = qaqili.list(adap, emr);
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    string emr = "select * from aftos where veziyeti ='DOLU'";
                    SqlDataAdapter adap = new SqlDataAdapter();
                    dataGridView1.DataSource = qaqili.list(adap, emr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xeta bas verdi!! : " + ex.Message + " - " + ex.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
