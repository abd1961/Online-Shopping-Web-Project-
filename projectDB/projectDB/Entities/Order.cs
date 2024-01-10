using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectDB.Entities
{

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        //User table linked with order to order
        //user navigation
        [ForeignKey("user")]
        public int UserId { get; set; }
        public User? user { get; set; }

    }
}
