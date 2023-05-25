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
    public partial class frmhastakayıt : Form
    {
        public frmhastakayıt()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        

        private void btnkayıtol_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("insert into tbl_hastalar(hastad,hastasoyad,hastatc,hastatelefon,hastasifre,hastacinsiyet) values(@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", txtad.Text);
            komut1.Parameters.AddWithValue("@p2",txtsoyad.Text);
            komut1.Parameters.AddWithValue("@p3",msktc.Text);
            komut1.Parameters.AddWithValue("@p4",msktelefon.Text);
            komut1.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut1.Parameters.AddWithValue("@p6",cmbcinsiyet.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız gerçekleşmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            
            
        }
    }
}
