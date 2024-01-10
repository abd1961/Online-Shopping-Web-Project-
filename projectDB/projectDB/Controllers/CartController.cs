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
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService= cartService;
        }


        /* 
         * To Add product to cart
         */
        [HttpPost,Route("AddToCart")]
        [Authorize]
        public IActionResult AddToCart([FromBody] ProductRequest product) 
        {
            try
            {

                if(product!=null)
                {
                    Cart cart = new Cart();
                    cart.ProductId = product.ProductId;
                    cart.UserId= product.UserId;
                    Boolean a = _cartService.AddToCart(cart);
                    if (a)
                    {
                        return StatusCode(200, new JsonResult("success"));
                    }
                }
            }
            catch (Exception ex) 
            {
                
            }
            return StatusCode(202, new JsonResult("unable to add/remove from cart"));
        }



        /* 
         * To remove product from cart
         */
        [HttpDelete,Route("RemoveFromCart/{productId}/{userId}")]
        [Authorize]
        public IActionResult RemoveFromCart([FromRoute]int productId, [FromRoute] int userId) 
        {
            ProductRequest product = new ProductRequest();
            product.ProductId = productId;
            product.UserId= userId;
            try
            {
                if (product != null)
                {
                    Cart cart = new Cart();
                    cart.ProductId = product.ProductId;
                    cart.UserId = product.UserId;
                    Boolean a = _cartService.RemoveFromCart(cart);
                    if (a)
                    {
                        return StatusCode(200, new JsonResult("Removed succesfully"));
                    }
                }

                return StatusCode(200, new JsonResult("unable to remove product form cart"));
            }
            catch (Exception ex)
            {
                return StatusCode(200,ex.Message);
            }
        }


        /* 
         * To get all cart products
         */
        [HttpGet, Route("getallcartproducts/{userId}")]
        [Authorize]
        public IActionResult getUserCartProducts([FromRoute] int userId)
        {
            try
            {
                List<Product> cartProducts = _cartService.GetAllCartProducts(userId);

                if(cartProducts!=null)
                {
                    return StatusCode(200,cartProducts);
                }
                
            }
            catch(Exception ex)
            {
                return StatusCode(202,ex.Message);
            }

            return StatusCode(202, new JsonResult("no products available"));
        }
    }   
}
