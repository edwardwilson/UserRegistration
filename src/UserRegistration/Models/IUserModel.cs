namespace UserRegistration.Models
{
    public interface IUserModel
    {
        string EmailAddress { get; }
        string Password { get; }
    }
}