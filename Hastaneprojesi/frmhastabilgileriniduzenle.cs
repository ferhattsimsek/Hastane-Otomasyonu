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
    public partial class frmhastabilgileriniduzenle : Form
    {
        public frmhastabilgileriniduzenle()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi bgl=new sqlbaglantisi();
        
        

        private void frmhastabilgileriniduzenle_Load(object sender, EventArgs e)
        {
            SqlCommand komut4 = new SqlCommand("select hastad,hastasoyad,hastatelefon,hastasifre,hastacinsiyet from tbl_hastalar where hastaTC=@p1", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr5 = komut4.ExecuteReader();
            while (dr5.Read())
            {
                msktc.Text = tc;
                txtad.Text = dr5[0].ToString();
                txtsoyad.Text=dr5[1].ToString();
                msktelefon.Text=dr5[2].ToString();
                txtsifre.Text=dr5[3].ToString();
                cmbcinsiyet.Text=dr5[4].ToString();
            }
            bgl.baglanti().Close();

        }

        private void btnbilgigüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut1=new SqlCommand("update tbl_hastalar set hastad=@p1,hastasoyad=@p2,hastatelefon=@p3,hastasifre=@p4,hastacinsiyet=@p5 where hastaTC=@p6",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",txtad.Text);
            komut1.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut1.Parameters.AddWithValue("@p3", msktelefon.Text);
            komut1.Parameters.AddWithValue("@p4", txtsifre.Text);
            komut1.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            komut1.Parameters.AddWithValue("@p6",msktc.Text);
            komut1.ExecuteNonQuery();
            
            bgl.baglanti().Close();
            MessageBox.Show("bilgileriniz güncellendi");
            this.Hide();
            
        }
    }
}
