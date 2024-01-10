using projectDB.Entities;
using projectDB.Models;

namespace projectDB.Services
{
    public interface IOrderService
    {
        Boolean AddOrder(Order order,int productId);
        void DeleteOrder(Order order);

        List<OrderAnonymousModel> GetAllOrders(int userId);

        Order GetOrderById(int id);
    }
}
