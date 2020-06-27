using System.ComponentModel.DataAnnotations;

namespace Backend4.Models.Users
{
    public class UserCredential : User
    {
        [EmailAddress]
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public bool UserExist { get; set; }
    }
}
