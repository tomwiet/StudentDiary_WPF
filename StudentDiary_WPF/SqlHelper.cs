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
        public static string ConnectionErrorMessage = string.Empty;
        public static (bool isConnected, string sqlErrorMessage) IsServerConnected()
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnetionString))
            {
                try
                {
                    connection.Open();
                    ConnectionErrorMessage = string.Empty;
                    return (true, "");
                }
                catch (SqlException ex)
                {
                    
                    ConnectionErrorMessage = $"Nie mozna się połączyc z bazą danych"                    
                        + $"{System.Environment.NewLine}"                    
                        + $"Sprawdź ustawienia";
                        return (false, ex.Message);
                }
            }
        }
    }
}
