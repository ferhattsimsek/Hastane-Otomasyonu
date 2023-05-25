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
    public partial class frmhastadetay : Form
    {
        public frmhastadetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi sql=new sqlbaglantisi();  
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmhastadetay_Load(object sender, EventArgs e)
        {
            lbltcno.Text = tc;
            SqlCommand komut=new SqlCommand("select hastad,hastasoyad from tbl_hastalar where hastaTC=@p1",sql.baglanti());
            komut.Parameters.AddWithValue("@p1",lbltcno.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                lbladsoyad.Text=dr[0]+" "+dr[1];
            }

            sql.baglanti().Close();
            // randevular
            DataTable dt = new DataTable();
           SqlDataAdapter da=new SqlDataAdapter("select * from tbl_randevular where hastaTC="+tc,sql.baglanti());
            da.Fill(dt);    
            dataGridView1.DataSource = dt;
            // branş çekme
            SqlCommand komut2 = new SqlCommand("select bransad from tbl_branslar", sql.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            sql.baglanti().Close();
            // doktor çekme
           
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();    
            SqlCommand komut3 = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@d1", sql.baglanti());
            komut3.Parameters.AddWithValue("@d1",cmbbrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            sql.baglanti().Close();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter("select * from tbl_randevular where randevubrans='" + cmbbrans.Text+"'"+" and randevudoktor='"+cmbdoktor.Text+"'and randevudurum=0", sql.baglanti());
            
            d.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lnkbilgileriniduzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmhastabilgileriniduzenle fr=new frmhastabilgileriniduzenle();
            fr.tc = lbltcno.Text;
            
            fr.Show();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtid.Text=dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnrandevual_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_randevular set randevudurum=1,hastatc=@p1,hastasikayet=@p2 where randevuid=@p3", sql.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltcno.Text);
            komut.Parameters.AddWithValue("@p2",rchsikayet.Text);
            komut.Parameters.AddWithValue("@p3", txtid.Text);
            komut.ExecuteNonQuery();
            sql.baglanti().Close();
            MessageBox.Show("randevu alınmıştır");

        }

        private void frmhastadetay_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
