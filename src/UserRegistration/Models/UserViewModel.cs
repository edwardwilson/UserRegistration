namespace UserRegistration.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class UserViewModel : IUserModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string EmailAddress { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,64}$", ErrorMessage = "Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit")]
        public string Password { get; set; }
    }
}
