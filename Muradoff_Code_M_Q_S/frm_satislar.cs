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
    
    public partial class frm_satislar : Form
    {
        afto_kira satis = new afto_kira();
        public frm_satislar()
        {
            InitializeComponent();
        }

        private void frm_satislar_Load(object sender, EventArgs e)
        {
            string emr6 = "Select * from satislar";
            SqlDataAdapter adapter5 = new SqlDataAdapter();
            dataGridView1.DataSource = satis.list(adapter5,emr6);
        }
    }
}
