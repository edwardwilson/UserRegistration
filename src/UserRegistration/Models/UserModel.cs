namespace UserRegistration.Models
{
    public class UserModel
    {
        public UserModel(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        public string EmailAddress { get; }
        public string Password { get; }
    }
}
