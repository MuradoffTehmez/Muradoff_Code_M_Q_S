using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Muradoff_Code_M_Q_S
{
    class afto_kira
    {
        SqlConnection con = new SqlConnection("Data Source=MURADOFF-CODE\\MURADOFF_CODE;Initial Catalog=masin_qeydi;Integrated Security=True");
        DataTable table;
        public void eleve_sil_deyis(SqlCommand command, string netice )
        {
            try
            {
                con.Open();
                command.Connection = con;
                command.CommandText = netice;
                command.ExecuteNonQuery();
                MessageBox.Show("    Icra Olundu    ","Diqqet",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi  sil deyisdir elave et  " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
            
        }
        public DataTable list(SqlDataAdapter adap, string sorgu)
        {
            try
            {
                table = new DataTable();
                adap = new SqlDataAdapter(sorgu, con);
                adap.Fill(table);
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi listelemek  " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
           
            }
            finally
            {
                con.Close();
            }          
            return table;
        }
        public void bos_masinlar(ComboBox combo, string iscode)
        {

            try
            {
                con.Open();
                SqlCommand kamanda = new SqlCommand(iscode,con);
                SqlDataReader rider = kamanda.ExecuteReader();
                while (rider.Read())
                {
                    combo.Items.Add(rider["plaka"].ToString());
                }
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi  bos masinlar " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }
        public static string addd;
        public void axtarmaq_kimlik (string Email, string ad, string vesiqe, string iscode)
        {
            try
            {
                con.Open();
                SqlCommand kamanda = new SqlCommand(iscode, con);
                SqlDataReader rider = kamanda.ExecuteReader();
                while (rider.Read())
                {
                    addd = rider["adi"].ToString();
                    //soyad = rider["soyadi"].ToString();
                    Email = rider["email"].ToString();
                    vesiqe = rider["vesiqe"].ToString();
                }
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi  musteri axtar " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }
        public void Axtarmaq_masin(string marka, string seriya, string model, string reng, string iscode)
        {
            try
            {
                con.Open();
                SqlCommand kamanda = new SqlCommand(iscode, con);
                SqlDataReader rider = kamanda.ExecuteReader();
                while (rider.Read())
                {
                    marka = rider["marka"].ToString();
                    seriya = rider["seriysa_nov"].ToString();
                    model = rider["modeli"].ToString();
                    reng = rider["rengi"].ToString();
                }
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi masin axtar  " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }
        public void hesablamaq(ComboBox combo_kira_nov, TextBox deyer, string iscode)
        {
            try
            {
                con.Open();
                SqlCommand kamanda = new SqlCommand(iscode, con);
                SqlDataReader rider = kamanda.ExecuteReader();
                while (rider.Read())
                {
                    if (combo_kira_nov.SelectedIndex == 0) deyer.Text = (double.Parse(rider["kira_qiymeti"].ToString()) * 1).ToString();
                    if (combo_kira_nov.SelectedIndex == 1) deyer.Text = (double.Parse(rider["kira_qiymeti"].ToString()) * 0.75).ToString();
                    if (combo_kira_nov.SelectedIndex == 2) deyer.Text = (double.Parse(rider["kira_qiymeti"].ToString()) * 0.70).ToString();

                }
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi hesabla  " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
            
        }
        public void satis_hesabla(SqlCommand emr, Label lbl,string sorgu)
        {
            try
            {
                con.Open();
                emr = new SqlCommand();
                lbl.Text = "Umumi qiymet";
            }
            catch (Exception ece)
            {
                MessageBox.Show("Xeta vardi  satis ehsabla  " + ece.Message + " - " + ece.StackTrace, "DİQQƏT", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            }
            finally
            {
                con.Close();
            }
        }
    }
}
