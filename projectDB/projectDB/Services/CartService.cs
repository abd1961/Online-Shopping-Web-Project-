using projectDB.Entities;
using projectDB.Models;
namespace projectDB.Services
{
    public class CartService:ICartService
    {
        private readonly CaseStudyDbContext _CartDBcontext;
        public CartService(CaseStudyDbContext cartDBcontext)
        {
            _CartDBcontext = cartDBcontext;
        }

        //Add to cart
        public Boolean AddToCart(Cart product)
        {
            try
            {
                //to get user
                User user = _CartDBcontext.Users.FirstOrDefault(e => e.UserId == product.UserId);
                Product productFound = _CartDBcontext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

                if (user != null && productFound != null)
                {
                    _CartDBcontext.CartProducts.Add(product);
                    _CartDBcontext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                throw;
            }
            return false;
        }


        //remove from cart 
        public Boolean RemoveFromCart(Cart product)
        {

            try
            {
                // valid user & product or not
                User user = _CartDBcontext.Users.FirstOrDefault(e => e.UserId == product.UserId);
                Product productFound = _CartDBcontext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

                if (user != null && productFound != null)
                {
                    _CartDBcontext.CartProducts.Remove(product);
                    _CartDBcontext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //To get all cart products
        public List<Product> GetAllCartProducts(int userId)
        {
            try
            {
                //to get user
                User user = _CartDBcontext.Users.FirstOrDefault(e => e.UserId == userId);
                if (user != null)
                {
                    List<Product> cartProducts =(from d in (from c in _CartDBcontext.CartProducts where c.UserId == userId select c)
                                          join p in _CartDBcontext.Products on d.ProductId equals p.ProductId select p).ToList();
                    return cartProducts;
                }
            }
            catch(Exception) 
            {
                throw;
            }
            return null;
        }


    }
}
