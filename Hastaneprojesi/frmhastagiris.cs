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

namespace Hastaneprojesi
{
    public partial class frmhastagiris : Form
    {
        public frmhastagiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi abc=new sqlbaglantisi();  

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lnkuyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmhastakayıt a=new frmhastakayıt();
            a.Show();

        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_hastalar where hastaTC=@a1 and hastasifre=@a2", abc.baglanti());
            cmd.Parameters.AddWithValue("@a1", msktc.Text);
            cmd.Parameters.AddWithValue("@a2",txtsifre.Text);
            SqlDataReader dr=cmd.ExecuteReader();
            if(dr.Read())
            {
                frmhastadetay a=new frmhastadetay();
                 a.tc=msktc.Text;
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı giriş yaptınız");

            }
            abc.baglanti().Close();
        }

        private void frmhastagiris_Load(object sender, EventArgs e)
        {

        }
    }
}
