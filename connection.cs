using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ExchangeSoftware
{
    class connection
    {
        public static string konektimi()
        {
            return("Data Source=mentor\\sqlexpress;Initial Catalog=exchange;Integrated Security=True");
        }

    }
}
