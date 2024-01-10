using projectDB.Entities;
using projectDB.Models;

namespace projectDB.Services
{
    public interface ICartService
    {
        //methods
        Boolean AddToCart(Cart product);

        Boolean RemoveFromCart(Cart product);

        List<Product> GetAllCartProducts(int userId);

    }
}
