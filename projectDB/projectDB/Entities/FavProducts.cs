using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projectDB.Entities
{
    public class FavProducts
    {
        //This FavouriteId == ProductId to get the 1 to 1 relation
        [Key]
        public int FavId { get; set; }

        [ForeignKey("FavProductId")]
        public int ProductId { get; set; }
        public Product FavProductId { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }

        //adding navigation from user 1 to many relation
        public User user { get; set; }



    }
}
