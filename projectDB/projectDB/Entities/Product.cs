using System.ComponentModel.DataAnnotations;

namespace projectDB.Entities
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }
        [Required]
        public double Price { get; set; }

        public string? ProductDescription { get; set; }
        [Required]
        public string? category { get; set; }

        public string ProductImgUrl { get; set; }
    }
}
