using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace ExchangeSoftware
{
    class moneyclass
    {

        public void data(DataGridView dg,Label l1,DateTimePicker dt1)
        {
            SqlConnection conn = new SqlConnection(connection.konektimi());
            DataTable dtaa = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("SELECT * FROM ExchangeConvert where Username='" + l1.Text+ "'AND Date LIKE'" + dt1.Text + "%'",conn);
            conn.Open();
            daa.Fill(dtaa);
            dg.DataSource = dtaa;
            conn.Close();
        }
    }
}
