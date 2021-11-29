using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Muradoff_Code_M_Q_S
{
    public partial class Frm_masin_qeydiyyat : Form
    {
        afto_kira aftos_qaqa = new afto_kira();
        public Frm_masin_qeydiyyat()
        {
            InitializeComponent();
        }

        private void Frm_masin_qeydiyyat_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
            catch (Exception eks)
            {
                MessageBox.Show("Prablem var" + eks.Message + " - " + eks.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("qeydiyyat icra olunsun ?", "DİQQƏT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialog == DialogResult.Yes)
            {
              try
                {
                    string emr = "insert into aftos(id,plaka,sehsiyet_id,marka,afto_nov,seriysa_nov,cixis_ili,modeli,rengi,yanacaq_nov,dozasi_,sureti,qiymeti,kira_qiymeti,skorus_payla,at_gucu,sekil_,veziyeti,tarix) values(@id,@plaka,@sehsiyet_id,@marka,@afto_nov,@seriysa_nov,@cixis_ili,@modeli,@rengi,@yanacaq_nov,@dozasi_,@sureti,@qiymeti,@kira_qiymeti,@skorus_payla,@at_gucu,@sekil_,@veziyeti,@tarix) ";
                    SqlCommand votka = new SqlCommand();
                    votka.Parameters.AddWithValue("@id", txt_qeydiyat_id.Text);
                    votka.Parameters.AddWithValue("@plaka", txt_plaka.Text);
                    votka.Parameters.AddWithValue("@sehsiyet_id", txt_kimlik_ide.Text);
                    votka.Parameters.AddWithValue("@marka", combo_marka.Text);
                    votka.Parameters.AddWithValue("@afto_nov", combo_afto_model_nov.Text);
                    votka.Parameters.AddWithValue("@seriysa_nov", combo_seriyasi.Text);
                    votka.Parameters.AddWithValue("@cixis_ili", Convert.ToDateTime(txt_afto_cixis_ili.Text));
                    votka.Parameters.AddWithValue("@modeli", txt_model.Text);
                    votka.Parameters.AddWithValue("@rengi", txt_rengi.Text);
                    votka.Parameters.AddWithValue("@yanacaq_nov", combo_afto_yanacaq_nov.Text);
                    votka.Parameters.AddWithValue("@dozasi_", combo_afto_dozasi.Text);
                    votka.Parameters.AddWithValue("@sureti", txt_sureti.Text);
                    votka.Parameters.AddWithValue("@qiymeti", txt_afto_qiymeti.Text);
                    votka.Parameters.AddWithValue("@kira_qiymeti", int.Parse(txt_afto_kira_qiymeti.Text));
                    votka.Parameters.AddWithValue("@skorus_payla", combo_afto_skorus_paylayici.Text);
                    votka.Parameters.AddWithValue("@at_gucu", txt_afto_at_gucu.Text);
                    votka.Parameters.AddWithValue("@sekil_", pictureBox1.ImageLocation);
                    votka.Parameters.AddWithValue("@veziyeti", "BOS");
                    votka.Parameters.AddWithValue("@tarix", Convert.ToDateTime(DateTime.Today.ToShortDateString()));
                    aftos_qaqa.eleve_sil_deyis(votka, emr);
                    temizle();
                 }
              catch (Exception eks)
                {
              MessageBox.Show("Prablem var" + eks.Message + " - " + eks.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
               
                }
            }
            else
            {
                MessageBox.Show("qeydiyyat olmadi", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void temizle()
        {
            combo_marka.Items.Clear();
            combo_afto_dozasi.Items.Clear();
            combo_afto_model_nov.Items.Clear();
            combo_afto_skorus_paylayici.Items.Clear();
            combo_afto_yanacaq_nov.Items.Clear();
            combo_seriyasi.Items.Clear();
            //foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in panel2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            pictureBox1.ImageLocation = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {               
                {

                }
            }
            catch 
            {
                
                {

                }
            
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
