using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Moudules
{
    public class DataBase
    {
        private MySqlConnection conn = null;

        public DataBase()
        {
            GetConnection();
        }

        public void ConnectionClose()
        {
            conn.Close();
        }

        private bool GetConnection()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = string.Format("server={0};user={1};password={2};database={3};port={4}", "gdc3.gudi.kr", "root", "1234", "test", "27002");

            try
            {
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MySqlDataReader GetReader(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = sql;
                comm.Connection = conn;

                return comm.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
