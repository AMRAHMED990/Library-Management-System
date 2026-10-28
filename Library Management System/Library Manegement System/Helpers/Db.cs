using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Library_Manegement_System
{
    public static class Db
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;

        public static async Task<DataTable> GetTableAsync(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(parameters);
                await con.OpenAsync();

                DataTable table = new DataTable();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    table.Load(reader);
                }
                return table;
            }
        }

        public static async Task<object> GetValueAsync(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(parameters);
                await con.OpenAsync();
                return await cmd.ExecuteScalarAsync();
            }
        }

        public static async Task<int> ExecuteAsync(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(parameters);
                await con.OpenAsync();
                return await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
