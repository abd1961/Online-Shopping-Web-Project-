using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectDB.Entities;
using projectDB.Services;

namespace projectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet,Route("GetProduct/{id}")]
        public IActionResult GetProduct(int id) 
        {
            try
            {
                Product product = _productService.GetProduct(id);
                if(product == null)
                {
                    return StatusCode(400,new JsonResult("no product found"));
                }
                return StatusCode(200, product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet,Route("GetAllProducts")]

        //GetAllProducts 
        public IActionResult GetAllProducts()
        {
            try
            {
                List<Product> products = _productService.getAllProducts();
                if(products!= null)
                {
                    return StatusCode(200,products);
                }
                else 
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Add product
        [HttpPost, Route("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                _productService.addProduct(product);
                return StatusCode(200, product);
               
            }
            catch (Exception e)
            {

                return StatusCode(400, e.Message);
            }
        }



        //delete product
        [HttpDelete, Route("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                Product product = _productService.GetProduct(id);
                if (product != null)
                {
                    _productService.deleteProduct(product);
                    return StatusCode(200, new JsonResult("product deleted"));
                }
                return StatusCode(200, new JsonResult("failed to delete"));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
