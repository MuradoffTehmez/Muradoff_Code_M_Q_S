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
    public partial class frm_giris : Form
    {
        public frm_giris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int san;
        private void timer1_Tick(object sender, EventArgs e)
        {
            san++;
            if (san == 5)
            {
                frm_login_page a = new frm_login_page();
                a.Show();
                this.Hide();
                timer1.Stop();
            }
        }

        private void frm_giris_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
