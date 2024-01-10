using System.ComponentModel.DataAnnotations;

namespace projectDB.Models
{
    public class OrderAnonymousModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        
        public double Price { get; set; }

        public string? ProductDescription { get; set; }
    
        public string? Category { get; set; }

        public string ProductImgUrl { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
