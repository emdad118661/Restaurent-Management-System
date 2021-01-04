using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturentsystem
{
    class MyConnection
    {
        public SqlConnection con;

        public MyConnection()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-SG9N9F6\SQLEXPRESS;Initial Catalog=Resturent;Integrated Security=True");
        }

        public static string type;

    }
}