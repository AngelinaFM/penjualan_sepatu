using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PENJUALAN_SEPATU
{
    public static class DBHelper
    {
        private static string ConnectionString = "Server =localhost; port=3306; database=sistempenjualansepatu;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
    //internal class DBhelper
    //{
    //}
}
