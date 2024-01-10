using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projectDB.Entities
{
    public class Cart
    {
        //Cart Primary key
        [Key]
        public int CartId { get; set; }

        [ForeignKey("CartProductId")]
        public int ProductId { get; set; }
        public Product CartProductId { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }

        //adding navigation from user 1 to many relation
        public User user { get; set; }
    }
}
