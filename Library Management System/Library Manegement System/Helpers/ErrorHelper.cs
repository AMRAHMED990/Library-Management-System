using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public static class ErrorHelper
    {
        public static void Show(Exception ex)
        {
            if (ex is ObjectDisposedException) return;   // the page was closed while it was still loading

            MessageBox.Show(GetMessage(ex), "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string GetMessage(Exception ex)
        {
            SqlException sqlError = ex as SqlException;
            if (sqlError != null)
            {
                switch (sqlError.Number)
                {
                    case 547:   // row is used by another table
                        return "This record is linked to other records (for example loans or fines), so it can't be deleted.";
                    case 2627:  // duplicate value
                    case 2601:
                        return "A record with the same value already exists (for example the same email).";
                    case -1:    // can't reach SQL Server
                    case 2:
                    case 53:
                    case 4060:
                        return "Can't connect to the database. Check that SQL Server is running and the connection string in App.config is correct.";
                    default:
                        return "Database error: " + sqlError.Message;
                }
            }

            if (ex is HttpRequestException)
                return "Couldn't reach Open Library. Check your internet connection.";

            return ex.Message;
        }
    }
}
