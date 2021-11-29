using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Muradoff_Code_M_Q_S
{
    public partial class frm_prakatol : Form
    {
        afto_kira Iscode = new afto_kira();
        public frm_prakatol()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=MURADOFF-CODE\\MURADOFF_CODE;Initial Catalog=masin_qeydi;Integrated Security=True");
        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_prakatol_Load(object sender, EventArgs e)
        {
            try
            {
                tezele_prakatol();
                bos_masin_goster();
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            DataGridView(dataGridView1);
        }

        private void bos_masin_goster()
        {
            string emr = "select * from aftos where veziyeti='BOS'";
            Iscode.bos_masinlar(combo_masinlar, emr);
        }

        private void tezele_prakatol()
        {
            try
            {
                string emr2 = "select * from prakakol";
                SqlDataAdapter adapter = new SqlDataAdapter();
                dataGridView1.DataSource = Iscode.list(adapter, emr2);
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                //if (txt_vesiqe.Text == "") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";          
                string emr2 = "select * from musteri_qey where vesiqe  = '" + txt_vesiqe.Text + "'";
                Iscode.axtarmaq_kimlik(txt_vesiqe.Text,txt_ad.Text,txt_telefon.Text,emr2);
                try
                {
                    con.Open();
                    SqlCommand kamanda = new SqlCommand(emr2, con);
                    SqlDataReader rider = kamanda.ExecuteReader();
                    while (rider.Read())
{
                        txt_ad.Text = rider["adi"].ToString();
                       // txt_soyad.Text = rider["soyadi"].ToString();
                        txt_telefon.Text = rider["email"].ToString();
                        txt_vesiqe.Text = rider["vesiqe"].ToString();
                        /*
                        addd = rider["adi"].ToString();
                        soyad = rider["soyadi"].ToString();
                        Email = rider["email"].ToString();
                        vesiqe = rider["vesiqe"].ToString();
                        */
                    }
                }
                catch (Exception ece)
                {
                    MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void combo_masinlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string emr5 = "select * from aftos where plaka  = '" +combo_masinlar.SelectedItem+ "'";
            Iscode.Axtarmaq_masin(txt_marka.Text, txt_seriyasi.Text, txt_model.Text, txt_reng.Text, emr5);
            try
            {
                con.Open();
                SqlCommand kamanda = new SqlCommand(emr5, con);
                SqlDataReader rider = kamanda.ExecuteReader();
                while (rider.Read())
                {
                    txt_marka.Text = rider["marka"].ToString();
                    txt_seriyasi.Text = rider["seriysa_nov"].ToString();
                    txt_model.Text = rider["modeli"].ToString();
                    txt_reng.Text = rider["rengi"].ToString();
                }
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }
        private void DataGridView(DataGridView dataGridView)
        {
            try
            {
                dataGridView.RowHeadersVisible = false;
                dataGridView.BorderStyle = BorderStyle.None;
                dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
                dataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView.DefaultCellStyle.SelectionForeColor = Color.Red;
                dataGridView.EnableHeadersVisualStyles = false;
                dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(42, 44, 46);
                dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;             
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "AD";
                dataGridView1.Columns[2].HeaderText = "E-MAİL";
                dataGridView1.Columns[3].HeaderText = "PRAVA";
                dataGridView1.Columns[4].HeaderText = "PRAVA_TARIXI";
                dataGridView1.Columns[5].HeaderText = "ALINDIGI_YER";
                dataGridView1.Columns[6].HeaderText = "QEYDIYYAT_NISANI";
                dataGridView1.Columns[7].HeaderText = "MARKA";
                dataGridView1.Columns[8].HeaderText = "SERIYA";
                dataGridView1.Columns[9].HeaderText = "MODEL";
                dataGridView1.Columns[10].HeaderText = "RENG";
                dataGridView1.Columns[11].HeaderText = "KIRALAMA_NOVU";
                dataGridView1.Columns[12].HeaderText = "KIRA_QIYMETI";
                dataGridView1.Columns[13].HeaderText = "MUDDETI";
                dataGridView1.Columns[14].HeaderText = "YEKUN_QIYMET";
                dataGridView1.Columns[15].HeaderText = "CIXIS_TARIXI";
                dataGridView1.Columns[16].HeaderText = "GIRIS_TARIXI";
               
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }

        }

        private void combo_kira_sekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string emr5 = "select * from aftos where plaka  = '" +combo_masinlar.SelectedItem + "'";
            Iscode.hesablamaq(combo_kira_sekli ,txt_kira_qiymeti, emr5);
            
             try
            {
                con.Open();
                SqlCommand kamanda = new SqlCommand(emr5, con);
                SqlDataReader rider = kamanda.ExecuteReader();
                while (rider.Read())
                {
                    if (combo_kira_sekli.SelectedIndex == 0) txt_kira_qiymeti.Text = (int.Parse(rider["kira_qiymeti"].ToString()) * 1).ToString();
                    if (combo_kira_sekli.SelectedIndex == 1) txt_kira_qiymeti.Text = (int.Parse(rider["kira_qiymeti"].ToString()) * 0.75).ToString();
                    if (combo_kira_sekli.SelectedIndex == 2) txt_kira_qiymeti.Text = (int.Parse(rider["kira_qiymeti"].ToString()) * 0.70).ToString();
                }
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
            
        }

        private void hesabla_tarix_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan gun_hesab = DateTime.Parse(tarix_giris.Text) - DateTime.Parse(tarix_cixis.Text);
                int gun_hesab2 = gun_hesab.Days;
                txt_gun.Text = gun_hesab2.ToString();
                txt_qiymet_opsi.Text = (gun_hesab2 * double.Parse(txt_kira_qiymeti.Text)).ToString();
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi   " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            temizlemek();
        }

        private void temizlemek()
        {
            try
            {
                tarix_cixis.Text = DateTime.Now.ToShortDateString();
                tarix_giris.Text = DateTime.Now.ToShortDateString();
                combo_kira_sekli.Text = "";
                combo_masinlar.Text = "";
                txt_ad.Clear();
                txt_marka.Clear();
                txt_model.Clear();
                txt_prava.Clear();
                prava_tarixi.Text = DateTime.Now.ToShortDateString();
                txt_reng.Clear();
                txt_seriyasi.Clear();
                //txt_soyad.Clear();
                txt_telefon.Clear();
                txt_verilme_tarixi.Clear();
                txt_vesiqe.Clear();
                txt_gun.Clear();
                txt_kira_qiymeti.Clear();
                txt_qiymet_opsi.Clear();
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi silme  " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            
        }

        private void btn_elave_et_Click(object sender, EventArgs e)
        {
            try
            {
                string Maya = "insert into prakakol(ID,ad_soyad,telefon,pravano,prava_tarix,prava_yeri,plaka,marka,seriyasi,ili,reng,kira_novu,kira_qiymeti,kira_gun,kira_qiymet,cixma_tarix,qayitma_tarix) values(@ID,@ad_soyad,@telefon,@pravano,@prava_tarix,@prava_yeri,@plaka,@marka,@seriyasi,@ili,@reng,@kira_novu,@kira_qiymeti,@kira_gun,@kira_qiymet,@cixma_tarix,@qayitma_tarix)";
                SqlCommand sibirka = new SqlCommand();
                sibirka.Parameters.AddWithValue("@ID", txt_vesiqe.Text);
                sibirka.Parameters.AddWithValue("@ad_soyad", txt_ad.Text);
                sibirka.Parameters.AddWithValue("@telefon", txt_telefon.Text);
                sibirka.Parameters.AddWithValue("@pravano", txt_prava.Text);
                sibirka.Parameters.AddWithValue("@prava_tarix", Convert.ToDateTime( prava_tarixi.Text));
                sibirka.Parameters.AddWithValue("@prava_yeri", txt_verilme_tarixi.Text);
                sibirka.Parameters.AddWithValue("@plaka", combo_masinlar.Text);
                sibirka.Parameters.AddWithValue("@marka", txt_marka.Text);
                sibirka.Parameters.AddWithValue("@seriyasi", txt_seriyasi.Text);
                sibirka.Parameters.AddWithValue("@ili", txt_model.Text);
                sibirka.Parameters.AddWithValue("@reng", txt_reng.Text);
                sibirka.Parameters.AddWithValue("@kira_novu", combo_kira_sekli.Text);
                sibirka.Parameters.AddWithValue("@kira_qiymeti",double.Parse( txt_kira_qiymeti.Text));
                sibirka.Parameters.AddWithValue("@kira_gun",double.Parse( txt_gun.Text));
                sibirka.Parameters.AddWithValue("@kira_qiymet",double.Parse( txt_qiymet_opsi.Text));
                sibirka.Parameters.AddWithValue("@cixma_tarix", Convert.ToDateTime(tarix_cixis.Text));
                sibirka.Parameters.AddWithValue("@qayitma_tarix", Convert.ToDateTime(tarix_giris.Text));
                Iscode.eleve_sil_deyis(sibirka,Maya);
                string krosofka = "Update aftos set veziyeti ='DOLU' where plaka ='"+combo_masinlar.Text+"'";
                SqlCommand aylaska = new SqlCommand();
                Iscode.eleve_sil_deyis(aylaska, krosofka);
                combo_masinlar.Items.Clear();
                bos_masin_goster();
                tezele_prakatol();
                temizlemek();
                MessageBox.Show("prakatol icra olundu", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi  elave et " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow coder = dataGridView1.CurrentRow;
                txt_vesiqe.Text = coder.Cells[0].Value.ToString();         //<ID>//
                txt_ad.Text = coder.Cells[1].Value.ToString();             //<ad_soyad>//
                txt_telefon.Text = coder.Cells[2].Value.ToString();        //<telefon>// 
                txt_prava.Text = coder.Cells[3].Value.ToString();          //<pravano>//  
                prava_tarixi.Text = coder.Cells[4].Value.ToString();       //<prava_tarix>// 
                txt_verilme_tarixi.Text = coder.Cells[5].Value.ToString(); //<prava_yeri>//  
                combo_masinlar.Text = coder.Cells[6].Value.ToString();     //<plaka>//  
                txt_marka.Text = coder.Cells[7].Value.ToString();          //<marka>// 
                txt_seriyasi.Text = coder.Cells[8].Value.ToString();       //<seriyasi>// 
                txt_model.Text = coder.Cells[9].Value.ToString();          //<ili>//  
                txt_reng.Text = coder.Cells[10].Value.ToString();          //<reng>// 
                combo_kira_sekli.Text = coder.Cells[11].Value.ToString();  //<kira_novu>//  
                txt_kira_qiymeti.Text = coder.Cells[12].Value.ToString();  //<kira_qiymeti>//  
                txt_gun.Text = coder.Cells[13].Value.ToString();           //<kira_gun>// 
                txt_qiymet_opsi.Text = coder.Cells[14].Value.ToString();   //<kira_qiymet>// 
                tarix_cixis.Text = coder.Cells[15].Value.ToString();       //<cixma_tarix>// 
                tarix_giris.Text = coder.Cells[16].Value.ToString();       //<qayitma_tarix>// 
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi ola bilmez  " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_deyisdir_Click(object sender, EventArgs e)
        {
            try
            {
                string emr = "update prakakol set ID=@ID,ad_soyad=@ad_soyad,telefon=@telefon,pravano=@pravano,prava_tarix=@prava_tarix,prava_yeri=@prava_yeri,marka=@marka,seriyasi=@seriyasi,ili=@ili,reng=@reng,kira_novu=@kira_novu,kira_qiymeti=@kira_qiymeti,kira_gun=@kira_gun,kira_qiymet=@kira_qiymet,cixma_tarix=@cixma_tarix,qayitma_tarix=@qayitma_tarix where plaka= '" + combo_masinlar.SelectedItem + "'";
                SqlCommand sibirka = new SqlCommand();
                sibirka.Parameters.AddWithValue("@ID", txt_vesiqe.Text);
                sibirka.Parameters.AddWithValue("@ad_soyad", txt_ad.Text);
                sibirka.Parameters.AddWithValue("@telefon", txt_telefon.Text);
                sibirka.Parameters.AddWithValue("@pravano", txt_prava.Text);
                sibirka.Parameters.AddWithValue("@prava_tarix", Convert.ToDateTime(prava_tarixi.Text));
                sibirka.Parameters.AddWithValue("@prava_yeri", txt_verilme_tarixi.Text);
                //sibirka.Parameters.AddWithValue("@plaka", combo_masinlar.Text);
                sibirka.Parameters.AddWithValue("@marka", txt_marka.Text);
                sibirka.Parameters.AddWithValue("@seriyasi", txt_seriyasi.Text);
                sibirka.Parameters.AddWithValue("@ili", txt_model.Text);
                sibirka.Parameters.AddWithValue("@reng", txt_reng.Text);
                sibirka.Parameters.AddWithValue("@kira_novu", combo_kira_sekli.Text);
                sibirka.Parameters.AddWithValue("@kira_qiymeti", double.Parse(txt_kira_qiymeti.Text));
                sibirka.Parameters.AddWithValue("@kira_gun", double.Parse(txt_gun.Text));
                sibirka.Parameters.AddWithValue("@kira_qiymet", double.Parse(txt_qiymet_opsi.Text));
                sibirka.Parameters.AddWithValue("@cixma_tarix", Convert.ToDateTime(tarix_cixis.Text));
                sibirka.Parameters.AddWithValue("@qayitma_tarix", Convert.ToDateTime(tarix_giris.Text));
                Iscode.eleve_sil_deyis(sibirka, emr);

                combo_masinlar.Items.Clear();
                bos_masin_goster();
                tezele_prakatol();
                temizlemek();
                MessageBox.Show("prakatol Deyisiklik edildi", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi  update  " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow coder = dataGridView1.CurrentRow;
                DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
                DateTime qayitma = DateTime.Parse(coder.Cells["qayitma_tarix"].Value.ToString());
                double qiymet = double.Parse(coder.Cells["kira_qiymet"].Value.ToString());
                TimeSpan eleve_qiymet = bugun - qayitma;
                double borc = eleve_qiymet.Days;
                double qiymet_ferq;
                qiymet_ferq = borc * qiymet;
                txt_elave_deyer_vergisi.Text = qiymet_ferq.ToString();
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi  tarix hesabla  " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow eseb = dataGridView1.CurrentRow;
            string emr = "delete from prakakol where plaka = '" +eseb.Cells["plaka"].Value.ToString()+ "'";
            SqlCommand komanda = new SqlCommand();
            Iscode.eleve_sil_deyis(komanda, emr);
            combo_masinlar.Items.Clear();
            combo_masinlar.Items.Clear();
            bos_masin_goster();
            tezele_prakatol();
            temizlemek();
            MessageBox.Show("pratakolda melemat silindi", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            bos_masin_goster();
            tezele_prakatol();
            temizlemek();
        }

        private void btn_tehvil_ver_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(txt_elave_deyer_vergisi.Text) != 0)
                {
                    //hesab
                    DataGridViewRow coder = dataGridView1.CurrentRow;
                    DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
                    double qiymet = double.Parse(coder.Cells["kira_qiymet"].Value.ToString());
                    double mebleq = double.Parse(coder.Cells["kira_qiymeti"].Value.ToString());
                    DateTime cixis_tarixi = DateTime.Parse(coder.Cells["cixma_tarix"].Value.ToString());
                    TimeSpan gun2 = bugun - cixis_tarixi;
                    double gun = gun2.Days;
                    double xerc = gun * qiymet;
                    //sil         
                    string emr = "delete from prakakol where plaka = '" + coder.Cells["plaka"].Value.ToString() + "'";
                    SqlCommand komanda = new SqlCommand();
                    Iscode.eleve_sil_deyis(komanda, emr);
                    //update
                    string emr2 = "update aftos set veziyeti = 'BOS' where plaka = '" + coder.Cells["plaka"].Value.ToString() + "'";
                    SqlCommand komanda2 = new SqlCommand();
                    Iscode.eleve_sil_deyis(komanda2, emr2);
                    // satisa eleve et
                    string emr3 = "insert into satislar(Id,ad_soyad,plaka,marka,seriya,model_il,reng,gun,qiymet,tutari,tarix1,tarix2) values(@Id,@ad_soyad,@plaka,@marka,@seriya,@model_il,@reng,@gun,@qiymet,@tutari,@tarix1,@tarix2)";
                    SqlCommand sibirka = new SqlCommand();
                    sibirka.Parameters.AddWithValue("@Id", coder.Cells["ID"].Value.ToString());
                    sibirka.Parameters.AddWithValue("@ad_soyad", coder.Cells["ad_soyad"].Value.ToString());
                    // sibirka.Parameters.AddWithValue("@telefon", txt_telefon.Text);
                    // sibirka.Parameters.AddWithValue("@pravano", txt_prava.Text);
                    // sibirka.Parameters.AddWithValue("@prava_tarix", Convert.ToDateTime(prava_tarixi.Text));
                    // sibirka.Parameters.AddWithValue("@prava_yeri", txt_verilme_tarixi.Text);
                    sibirka.Parameters.AddWithValue("@plaka", coder.Cells["QEYDIYYAT_NISANI"].Value.ToString());
                    sibirka.Parameters.AddWithValue("@marka", coder.Cells["MARKA"].Value.ToString());
                    sibirka.Parameters.AddWithValue("@seriya", coder.Cells["SERIYA"].Value.ToString());
                    sibirka.Parameters.AddWithValue("@model_il", coder.Cells["MODEL"].Value.ToString());
                    sibirka.Parameters.AddWithValue("@reng", coder.Cells["RENG"].Value.ToString());
                    // sibirka.Parameters.AddWithValue("@kira_novu", combo_kira_sekli.Text);
                    // sibirka.Parameters.AddWithValue("@kira_qiymeti", double.Parse(txt_kira_qiymeti.Text));
                    sibirka.Parameters.AddWithValue("@gun", gun);
                    sibirka.Parameters.AddWithValue("@qiymet",xerc);
                    sibirka.Parameters.AddWithValue("@tutari",mebleq);
                    sibirka.Parameters.AddWithValue("@tarix1", coder.Cells["CIXIS_TARIXI"].Value.ToString());
                    sibirka.Parameters.AddWithValue("@tarix2", DateTime.Now.ToShortDateString());                   
                    Iscode.eleve_sil_deyis(sibirka, emr3);
                    MessageBox.Show("Masin teslim edildi", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    
                    combo_masinlar.Items.Clear();
                    bos_masin_goster();
                    tezele_prakatol();
                    temizlemek();
                    txt_elave_deyer_vergisi.Text = "";
                }
                else
                {
                    MessageBox.Show("surucunun adini ve qeydiyyat nomresini yazin", "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi  Tehvil ver " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void txt_qiymet_opsi_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
