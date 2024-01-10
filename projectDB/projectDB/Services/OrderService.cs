using projectDB.Entities;
using projectDB.Models;

namespace projectDB.Services
{
    public class OrderService: IOrderService
    {
        private readonly CaseStudyDbContext dbContextOrder;

        public OrderService(CaseStudyDbContext _dbContextOrder)
        {
            this.dbContextOrder = _dbContextOrder;
        }
        //add order
        //tables connection : Order table ---> OrderedProduct table
        public Boolean AddOrder(Order order,int productId)
        {
            //checking for valid product or not
            Product prod = dbContextOrder.Products.FirstOrDefault(e => e.ProductId == productId);

            if (order!=null && prod!=null)
            {
                
                dbContextOrder.Orders.Add(order);
                dbContextOrder.SaveChanges();

                //Adding 
                OrderedProducts op = new OrderedProducts();
                op.ProductId = productId;
                op.orderId = (from or in dbContextOrder.Orders.OrderByDescending(o => o.OrderDate)
                             where or.UserId == order.UserId 
                             select or.OrderId).First();
                dbContextOrder.OrderedProducts.Add(op);
                dbContextOrder.SaveChanges();
                return true;
            }
            return false;
        }


        //delete order
        public void DeleteOrder(Order order)
        {
            dbContextOrder.Orders.Remove(order);    
            dbContextOrder.SaveChanges();
        }

        //get all orders

        public List<OrderAnonymousModel> GetAllOrders(int userId)
        {
            //to get all orders
            //List<OrderAnonymousModel> allOrders = (from u in (from o in dbContextOrder.Orders
            //                           join op in dbContextOrder.OrderedProducts on o.OrderId equals op.orderId
            //                           select new OrderAnonymousModel()
            //                           {
            //                               OrderId = o.OrderId,
            //                               OrderDate = o.OrderDate,
            //                               UserId = o.UserId,
            //                               ProductId = op.ProductId
            //                           })
            //                where u.UserId == userId && u.ProductId == productId
            //                select u).ToList();

            List<OrderAnonymousModel> allOrders = (from ap in (from u in (from o in dbContextOrder.Orders
                                                   join op in dbContextOrder.OrderedProducts on o.OrderId equals op.orderId
                                                   select new 
                                                   {
                                                        o.OrderId,
                                                        o.OrderDate,
                                                        o.UserId,
                                                        op.ProductId
                                                   })
                                        where u.UserId == userId
                                        select u)
                            join p in dbContextOrder.Products on ap.ProductId equals p.ProductId
                            select new OrderAnonymousModel()
                            {
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                Price= p.Price,
                                ProductDescription = p.ProductDescription,
                                Category = p.category,
                                ProductImgUrl = p.ProductImgUrl,
                                OrderId = ap.OrderId,
                                OrderDate = ap.OrderDate

                            }).ToList();
                         


            return allOrders;
        }

        //get order by id
        public Order GetOrderById(int id)
        {
            return dbContextOrder.Orders.Find(id);
        }


        //Get all order items
        public List<OrderedProducts> GetAllOrderItems()
        {
            return dbContextOrder.OrderedProducts.ToList();

        }

    }
}
