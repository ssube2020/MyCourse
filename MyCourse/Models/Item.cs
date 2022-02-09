using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCourse.Models
{
    public class Item
    {

        public int id { get; set; }
        
        [Required(ErrorMessage = "შეიყვანეთ მანქანის მოდელი")]
        public string borrower { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ საწვავის ტიპი")]
        public string lender { get; set; }
        [Required(ErrorMessage = "აირჩიეთ საჭე")]
       // [Range(0, int.MaxValue, ErrorMessage = "რიცხვი უნდა იყოს ერთზე დიდი")]
        public string itemname { get; set; }
        [ForeignKey("id")]
        public int categoryId { get; set; }  
        public Category? Category { get; set; }

    }
}
