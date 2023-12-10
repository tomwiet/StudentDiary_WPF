using StudentDiary_WPF.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDiary_WPF
{
    public static class SqlHelper
    {
        public static (bool isConnected, string sqlErrorMessage) IsServerConnected()
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnetionString))
            {
                try
                {
                    connection.Open();
                    return (true, "");
                }
                catch (SqlException ex)
                {
                    return (false, ex.Message);
                }
            }
        }
    }
}
