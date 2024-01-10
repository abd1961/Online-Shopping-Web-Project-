using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace projectDB.Entities
{
    public class OrderedProducts
    {
        //this is unique key for OrderedProducts table
        [Key]
        public int OrderedProductId { get; set; }

        //This is actual productId
        [Required]
        public int ProductId { get; set; }

        //array of order items(one to many relationship one order can have multiple items)
        //order navigation
        [Required]
        [ForeignKey("order")]
        public int orderId { get; set; }

        public Order order { get; set; }
    }
}
