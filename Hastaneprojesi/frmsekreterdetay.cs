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
    public partial class frmsekreterdetay : Form
    {
        public frmsekreterdetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string sekretertc;

        private void frmsekreterdetay_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sekreteradsoyad from tbl_sekreter where sekretertc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", sekretertc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0].ToString();
                lbltc.Text = sekretertc.ToString();


            }
            bgl.baglanti().Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select bransad from tbl_branslar ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select(doktorad + ' ' + doktorsoyad) as 'doktorlar', doktorbrans from tbl_doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            SqlCommand komut2 = new SqlCommand("select bransad from tbl_branslar", bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();
            




        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut3=new SqlCommand("insert into tbl_randevular (randevutarih,randevusaat,randevubrans,randevudoktor) values(@r1,@r2,@r3,@r4)",bgl.baglanti());
            komut3.Parameters.AddWithValue("@r1", msktarih.Text);
            komut3.Parameters.AddWithValue("@r2", msksaat.Text);
            komut3.Parameters.AddWithValue("@r3", cmbbrans.Text);
            komut3.Parameters.AddWithValue("@r4", cmbdoktor.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            


        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr3=komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();

        }

        private void btnduyuruolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut5=new SqlCommand("insert into tbl_duyuru (duyuru) values (@d1)",bgl.baglanti());
            komut5.Parameters.AddWithValue("@d1",rchduyuru.Text);
            komut5.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("duyuru oluşturuldu");

        }

        private void btndoktorpanel_Click(object sender, EventArgs e)
        {
            frmdoktorpaneli drp=new frmdoktorpaneli();
            drp.Show();
        }

        private void btnrandevuliste_Click(object sender, EventArgs e)
        {
            frmrandevulistesi frl=new frmrandevulistesi();
            frl.Show();
        }

        private void btnbranspanel_Click(object sender, EventArgs e)
        {
            frmbrans frmb = new frmbrans();
            frmb.Show();
        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            frmduyurular frmd=new frmduyurular();
            frmd.Show();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
