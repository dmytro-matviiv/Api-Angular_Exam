using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_927.DataAccess
{
        [Table("tb1Product")]
    public class Product
    {
        
            [Key]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Price { get; set; }
            [Required]
            public string Color { get; set;}
            [Required]
            public string Size { get; set;}
            [Required]
            public string URL_Image { get; set;}
            [Required]
            public string Details { get; set;}
        
    }
}