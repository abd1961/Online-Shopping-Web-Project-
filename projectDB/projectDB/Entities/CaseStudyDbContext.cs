using Microsoft.EntityFrameworkCore;

namespace projectDB.Entities
{
    public class CaseStudyDbContext : DbContext
    {

        public CaseStudyDbContext(DbContextOptions<CaseStudyDbContext> options) : base(options)
        {

        }


        //Entity set
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<OrderedProducts> OrderedProducts { get; set; }

        public DbSet<FavProducts> FavOrderItems { get; set; }

        public DbSet<Cart> CartProducts { get; set; }

    }
}
