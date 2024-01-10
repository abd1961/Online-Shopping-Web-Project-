using projectDB.Entities;

namespace projectDB.Services
{
    public interface IProductService
    {
        //Interface methods
        void addProduct(Product prod);

        //Admin role can do this
        void deleteProduct(Product prod);

        List<Product> getAllProducts();

        //get product

        Product GetProduct(int id);




    }
}
