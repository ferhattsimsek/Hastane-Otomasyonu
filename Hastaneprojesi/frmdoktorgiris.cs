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
    public partial class frmdoktorgiris : Form
    {
        public frmdoktorgiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_doktorlar where doktortc=@p1 and doktorsifre=@p2", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",msktc.Text);
            cmd.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                frmdoktorbilgi fr=new frmdoktorbilgi(); 
                fr.doktortc=msktc.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("bilgileriniz hatalıdır");
            }
        }
    }
}
