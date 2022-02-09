using System.ComponentModel.DataAnnotations;

namespace MyCourse.ViewModels
{
    public class LoginVM
    {
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        [Display(Name ="remember me?")]
        public bool rememberme { get; set; }

    }
}
