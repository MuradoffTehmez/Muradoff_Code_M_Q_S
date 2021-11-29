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
    public partial class frm_musteri_siyahisi : Form

    {
        afto_kira afto = new afto_kira();
        public frm_musteri_siyahisi()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            DataGridViewRow viewRow = dataGridView1.CurrentRow;
            //string emr5 = "delete from musteri_qey where vesiqe = '" + txt_vesiqe_nom.Text + "'";
            string emr5 = "delete from musteri_qey where vesiqe = '" + txt_vesiqe_nom.Text + "'";
            SqlCommand sqlCommand = new SqlCommand();
            afto.eleve_sil_deyis(sqlCommand, emr5);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            goster_list();
        }
        

        private void frm_musteri_siyahisi_Load(object sender, EventArgs e)
        {
            goster_list();
            DataGridView(dataGridView1);
        }

        private void goster_list()
        {
            string kod_setri = "select * from musteri_qey";
            SqlDataAdapter adapter = new SqlDataAdapter();
            dataGridView1.DataSource = afto.list(adapter, kod_setri);
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kod_setri = "select * from musteri_qey where vesiqe like '%" + textBox1.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter();
                dataGridView1.DataSource = afto.list(adapter, kod_setri);
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kod_setri1 = "select * from musteri_qey where adi like '%" + textBox2.Text + "%'";
                SqlDataAdapter adapter1 = new SqlDataAdapter();
                dataGridView1.DataSource = afto.list(adapter1, kod_setri1);
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kod_setri2 = "select * from musteri_qey where qan like '%" + textBox3.Text + "%'";
                SqlDataAdapter adapter2 = new SqlDataAdapter();
                dataGridView1.DataSource = afto.list(adapter2, kod_setri2);
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kod_setri3 = "select * from musteri_qey where tarix like '%" + textBox4.Text + "%'";
                SqlDataAdapter adapter3 = new SqlDataAdapter();
                dataGridView1.DataSource = afto.list(adapter3, kod_setri3);
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow viewRow = dataGridView1.CurrentRow;
                txt_soyad.Text = viewRow.Cells[0].Value.ToString();
                txt_ad.Text = viewRow.Cells[1].Value.ToString();
                txt_email.Text = viewRow.Cells[2].Value.ToString();
                comboBox1.Text = viewRow.Cells[3].Value.ToString();
                tct_vetendas.Text = viewRow.Cells[4].Value.ToString();
                txt_dogum_tax.Text = viewRow.Cells[5].Value.ToString();
                txt_vesiqe_nom.Text = viewRow.Cells[6].Value.ToString();
                comboBox2.Text = viewRow.Cells[7].Value.ToString();
                txt_vesiqenin_verilmr_tax.Text = viewRow.Cells[8].Value.ToString();
                txt_vesuqenun_son_istifade_tarixi.Text = viewRow.Cells[9].Value.ToString();
                textBox5.Text = viewRow.Cells[10].Value.ToString();
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
               
            }
           
        }

        private void btn_deyis_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Melumatlar deyisilsin ?  ", "DİQQƏT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (dialog == DialogResult.Yes)
            {
                string emr = "update musteri_qey set soyadi=@soyadi,adi=@adi,email=@email,cinsi=@cinsi,verendasliq=@verendasliq,dag_tarix=@dag_tarix,vesiqe=@vesiqe,qan=@qan,ves_son_is=@ves_son_is where vesiqe=@vesiqe";
                SqlCommand kom = new SqlCommand();
                kom.Parameters.AddWithValue("@soyadi", txt_soyad.Text);
                kom.Parameters.AddWithValue("@adi", txt_ad.Text);
                kom.Parameters.AddWithValue("@email", txt_email.Text);
                kom.Parameters.AddWithValue("@cinsi", comboBox1.Text);
                kom.Parameters.AddWithValue("@verendasliq", tct_vetendas.Text);
                kom.Parameters.AddWithValue("@dag_tarix", txt_dogum_tax.Text);
                kom.Parameters.AddWithValue("@vesiqe",txt_vesiqe_nom.Text);
                kom.Parameters.AddWithValue("@qan", comboBox2.Text);
                kom.Parameters.AddWithValue("@ves_verilme",txt_vesiqenin_verilmr_tax.Text);
                kom.Parameters.AddWithValue("@ves_son_is",txt_vesuqenun_son_istifade_tarixi.Text);
                kom.Parameters.AddWithValue("@tarix", Convert.ToDateTime(DateTime.Today.ToShortDateString()));
                afto.eleve_sil_deyis(kom, emr);
                MessageBox.Show("Siz Uğurla melumatlarinizi deyisdirdiniz", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                goster_list();
            }
            else
            {
                MessageBox.Show("Deyisiklik  olmadi ! ! ", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                //    foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
        }
        private void DataGridView(DataGridView dataGridView)
        {
            try
            {
                dataGridView.RowHeadersVisible = false;
                dataGridView.BorderStyle = BorderStyle.None;
                dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(59, 53, 57);
                dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 50, 70);
                dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
                dataGridView.EnableHeadersVisualStyles = false;
                dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(42, 44, 46);
                dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[0].HeaderText = "SOYADİ";
                dataGridView1.Columns[1].HeaderText = "ADİ";
                dataGridView1.Columns[2].HeaderText = "E-MAİL";
                dataGridView1.Columns[3].HeaderText = "CİNSİ";
                dataGridView1.Columns[4].HeaderText = "VETENDASLİQ";
                dataGridView1.Columns[5].HeaderText = "DOGUM_TARİXİ";
                dataGridView1.Columns[6].HeaderText = "VESİQE";
                dataGridView1.Columns[7].HeaderText = "QAN_QRUPU";
                dataGridView1.Columns[8].HeaderText = "VESİQE_TARİXİ";
                dataGridView1.Columns[9].HeaderText = "SON_İSTİFADE_TARİXİ";
                dataGridView1.Columns[10].HeaderText = "QEYDİYYAT_TARİXİ";
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}