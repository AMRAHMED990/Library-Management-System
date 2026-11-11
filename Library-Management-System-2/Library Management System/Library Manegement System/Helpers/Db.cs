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

        public static async Task EnsureDatabaseSchemaAsync()
        {
            try
            {
                // Ensure Role column exists in logintab
                string addRoleSql = @"
                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('logintab') AND name = 'Role')
                BEGIN
                    ALTER TABLE logintab ADD Role NVARCHAR(20) NOT NULL CONSTRAINT DF_logintab_Role DEFAULT 'Admin';
                END";
                await ExecuteAsync(addRoleSql);

                // Ensure demo subadmin user exists
                string addSubadminSql = @"
                IF NOT EXISTS (SELECT 1 FROM logintab WHERE Username = 'subadmin')
                BEGIN
                    INSERT INTO logintab (Username, Password_Hash, Full_Name, Role)
                    VALUES (N'subadmin', CONVERT(CHAR(64), HASHBYTES('SHA2_256', N'subadmin123'), 2), N'Library Subadmin', N'Subadmin');
                END";
                await ExecuteAsync(addSubadminSql);
            }
            catch
            {
                // In case database is temporarily unreachable; handled gracefully at login
            }
        }

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
