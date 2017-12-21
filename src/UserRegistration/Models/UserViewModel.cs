namespace UserRegistration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,64}$")]
        public string Password { get; set; }
    }
}
