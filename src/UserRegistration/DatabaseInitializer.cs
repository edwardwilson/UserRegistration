namespace UserRegistration
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    public static class DatabaseInitializer
    {
        public static void Initialize(string connectionString)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.ChangeDatabase("master");

                using (SqlCommand sqlCmd = new SqlCommand("SELECT COUNT(*) FROM master.sys.databases WHERE name = N'UserRegistration'", connection))
                {
                    int exists = (int)sqlCmd.ExecuteScalar();

                    if (exists <= 0)
                    {
                        CreateDatabaseAndTables(connection);
                    }
                }
            }
        }

        private static void CreateDatabaseAndTables(SqlConnection connection)
        {
            using (StreamReader sr = new StreamReader("Initialize.sql"))
            {
                String script = sr.ReadToEnd();

                using (SqlCommand sqlCmd = new SqlCommand(script, connection))
                {
                    int exists = sqlCmd.ExecuteNonQuery();

                    if (exists <= 0)
                    {
                        CreateDatabaseAndTables(connection);
                    }
                }
            }
        }
    }
}