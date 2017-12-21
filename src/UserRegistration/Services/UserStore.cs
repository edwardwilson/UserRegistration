namespace UserRegistration.Services
{
    using UserRegistration.Models;

    public class UserStore : IUserStore
    {
        private readonly ISqlDataAccess<UserModel> sqlDataAccess;

        public UserStore(ISqlDataAccess<UserModel> sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }

        public void AddUser(UserViewModel viewModel)
        {
            (string salt, string passwordHash) hash = PasswordHasher.HashPassword(viewModel.Password);

            var model = new UserModel(
                viewModel.EmailAddress,
                hash.passwordHash,
                hash.salt);

            sqlDataAccess.Insert(model);
        }

        public bool EmailUnique(string email)
        {
            return sqlDataAccess.Exists($"SELECT COUNT(*) FROM UserDetail WHERE LOWER(EmailAddress) = LOWER('{email}')");
        }
    }
}