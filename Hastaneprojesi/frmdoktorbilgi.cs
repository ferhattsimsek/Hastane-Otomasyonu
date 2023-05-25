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
    public partial class frmdoktorbilgi : Form
    {
        public frmdoktorbilgi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string doktortc;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void frmdoktorbilgi_Load(object sender, EventArgs e)
        {
            lbltc.Text = doktortc;

            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", doktortc);
            SqlDataReader da = komut.ExecuteReader();
            while (da.Read())
            {
                lbladsoyad.Text = da[0] + " " + da[1];

            }
            bgl.baglanti().Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_randevular where randevudoktor='"+lbladsoyad.Text+"'", bgl.baglanti());
            da2.Fill(dt);
            dataGridView1.DataSource = dt;
            


        }

        private void btncıkısyap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            frmduyurular fr = new frmduyurular();
            fr.Show();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            frmdoktorbilgiduzenle fr = new frmdoktorbilgiduzenle();
            fr.tc = doktortc;
            fr.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchsikayet.Text=dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
