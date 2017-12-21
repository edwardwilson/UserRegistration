namespace UserRegistration.Services
{
    using System.Data.SqlClient;
    using UserRegistration.Models;

    public class UserModelSqlDataAccess : ISqlDataAccess<UserModel>
    {
        private readonly string connectionString;

        public UserModelSqlDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Insert(UserModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCmd = 
                    new SqlCommand($"INSERT INTO UserDetail (EmailAddress, Password, Salt) VALUES('{model.EmailAddress}', '{model.Password}', '{model.Salt}')", connection))
                {
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public bool Exists(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                {
                    return (int)sqlCmd.ExecuteScalar() <= 0;
                }
            }
        }
    }

    public interface ISqlDataAccess<in T>
    {
        void Insert(T model);
        bool Exists(string query);
    }
}
