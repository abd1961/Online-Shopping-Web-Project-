using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectDB.Entities;
using projectDB.Models;
using projectDB.Services;

namespace projectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        //private readonly IOrderedProductsService _orderItemsService;
     

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
            //_orderItemsService = orderItems;
        }


        //To add order endpoint

        [HttpPost,Route("AddOrder")]
        [Authorize]  //this actully checks whether the user is authenticated or not
        public IActionResult AddOrder(ProductRequest product) 
        {
            try
            {
                if (product != null)
                {
                    Order order = new Order();
                    order.OrderDate = DateTime.Now;
                    order.UserId = product.UserId;
                    Boolean o = _orderService.AddOrder(order,product.ProductId);
                    if(o)
                    {
                        return StatusCode(200,new JsonResult("Order completed"));
                    }
                    else
                    {
                        return StatusCode(400, new JsonResult("failed to Order the product"));
                    }
                }
                return StatusCode(400, new JsonResult("failed to add"));
            }
            catch (Exception)
            {

                throw;
            }
        }


        //To get all orders endpoint
        [HttpGet,Route("GetAllOrders/{userId}")]
        public IActionResult GetAllOrders([FromRoute] int userId)
        {
            try
            {
                List<OrderAnonymousModel> orders = _orderService.GetAllOrders(userId);

                if(orders!=null)
                {
                    return StatusCode(200, orders);
                }
                
                return StatusCode(400, new JsonResult("no order found"));
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
         * Place Order = collection of products in cart
         */

 


        //delete orders
        [HttpDelete,Route("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                Order order = _orderService.GetOrderById(id);
                if(order != null)
                {
                    _orderService.DeleteOrder(order);
                    return StatusCode(200,"order deleted");
                }
                return StatusCode(400,new JsonResult("deletion failed"));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //get order by id
        [HttpGet,Route("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                Order order = _orderService.GetOrderById(id);
                if(order!=null)
                    return StatusCode(200, order);
                return StatusCode(400,"no order found");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
