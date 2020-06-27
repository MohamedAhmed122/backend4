using System.ComponentModel.DataAnnotations;

namespace Backend4.Models.Users
{
    public class User
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public int? Day { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public int? Year { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
