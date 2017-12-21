namespace UserRegistration.Services
{
    using UserRegistration.Models;

    public interface IUserStore
    {
        void AddUser(UserViewModel viewModels);
        bool EmailUnique(string email);
    }
}