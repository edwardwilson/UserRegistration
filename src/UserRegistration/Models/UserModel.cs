namespace UserRegistration.Models
{
    public class UserModel : IUserModel
    {
        public UserModel(string emailAddress, string password, string salt)
        {
            EmailAddress = emailAddress;
            Password = password;
            Salt = salt;
        }

        public string EmailAddress { get; }
        public string Password { get; }
        public string Salt { get; set; }
    }
}
