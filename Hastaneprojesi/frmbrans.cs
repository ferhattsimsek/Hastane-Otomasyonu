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
    public partial class frmbrans : Form
    {
        public frmbrans()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();  
        private void frmbrans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("select * from tbl_branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtbrans.Text=dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut1=new SqlCommand("insert into tbl_branslar (bransad)values(@p1)",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",txtbrans.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("branş eklenmiştir");
            this.Hide();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("delete from tbl_branslar where bransid=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtid.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("branş silinmiştir");
            this.Hide();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("update tbl_branslar set bransad=@p1 where bransid=@p2", bgl.baglanti());

            komut3.Parameters.AddWithValue("@p1", txtbrans.Text);
            komut3.Parameters.AddWithValue("@p2", txtid.Text);

            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("branş güncellenmiştir");
            this.Hide();

        }
    }
}
