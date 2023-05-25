using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastaneprojesi
{
     class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan=new SqlConnection("Data Source=LAPTOP-JKCGOLGI\\MSSQLSERVERR;Initial Catalog=hastaneproje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
