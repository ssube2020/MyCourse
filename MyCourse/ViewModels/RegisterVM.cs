using System.ComponentModel.DataAnnotations;

namespace MyCourse.ViewModels
{
    public class RegisterVM
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        [StringLength(100,ErrorMessage ="the {0} must be at least {2} characters legth"),MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; }
        [Display(Name = "confirm password")]
        [Compare("Password", ErrorMessage ="passwords does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }

    }
}
