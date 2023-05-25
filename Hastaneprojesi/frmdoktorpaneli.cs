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
    public partial class frmdoktorpaneli : Form
    {
        public frmdoktorpaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void frmdoktorpaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_doktorlar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("insert into tbl_doktorlar (doktorad,doktorsoyad,doktortc,doktorbrans,doktorsifre)values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", txtad.Text);
            komut1.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut1.Parameters.AddWithValue("@p3", msktcno.Text);
            komut1.Parameters.AddWithValue("@p4", cmbbrans.Text);
            komut1.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("doktor eklendi");

            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            msktcno.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbbrans.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("delete from tbl_doktorlar where doktortc=@d1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@d1",msktcno.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("doktor silinmiştir");
            this.Hide();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update  tbl_doktorlar set doktorad=@d1,doktorsoyad=@d2,doktorbrans=@d4,doktorsifre=@d5 where doktortc=@d6", bgl.baglanti());

            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@d4", cmbbrans.Text);
            komut.Parameters.AddWithValue("@d5", txtsifre.Text);

            komut.Parameters.AddWithValue("@d6", msktcno.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("güncellenmiştir");
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
