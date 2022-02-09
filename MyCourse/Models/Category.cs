using System.ComponentModel.DataAnnotations;

namespace MyCourse.Models
{
    public class Category
    {

        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "ჩაწერეთ ბრენდის სახელი")]
        public string category { get; set; }
    }
}
