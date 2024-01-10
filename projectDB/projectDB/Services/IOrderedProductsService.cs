using projectDB.Entities;

namespace projectDB.Services
{
    public interface IOrderedProductsService
    {
        List<OrderedProducts> GetAllOrderItems();
    }
}
