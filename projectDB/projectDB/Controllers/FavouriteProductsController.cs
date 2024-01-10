using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectDB.DTO;
using projectDB.Entities;
using projectDB.Models;
using projectDB.Services;
using System.Security.Claims;

namespace projectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteProductsController : ControllerBase
    {
        private readonly IFavouritesService _favouritesService;
        //private readonly int LocalUserId;

        public FavouriteProductsController(IFavouritesService favouritesService)
        {
            _favouritesService = favouritesService;
        }

        //add fav products
        [HttpPost, Route("AddFavProduct")]
        [Authorize]  //this actully checks whether the user is authenticated or not
        public IActionResult AddToFav([FromBody] ProductRequest product)
        {
            try
            {
                if (product != null)
                {
                    FavProducts prod = new FavProducts();
                    prod.ProductId = product.ProductId;
                    prod.UserId = product.UserId;
                    Boolean ar = _favouritesService.AddToFav(prod);
                    if(ar && prod.UserId>0)
                    {
                        return StatusCode(200,_favouritesService.GetAllFavProducts(prod.UserId));
                    }
                    else
                    {
                        return StatusCode(200, _favouritesService.GetAllFavProducts(prod.UserId));
                    }  
                }
                return StatusCode(400, new JsonResult("failed to add"));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Remove from fav
        [HttpPost, Route("RemoveFromFav")]
        [Authorize]
        public IActionResult RemoveFav([FromBody] ProductRequest favProd)
        {
            try
            {
                if (favProd != null)
                {
                    FavProducts prod = new FavProducts();
                    prod.ProductId = favProd.ProductId;
                    prod.UserId = favProd.UserId;

                    Boolean removedOrNot = _favouritesService.RemoveFromFav(prod);

                    if (removedOrNot)
                    {
                        return StatusCode(200, _favouritesService.GetAllFavProducts(favProd.UserId));
                    }
                }
                return StatusCode(400, new JsonResult("There is no product"));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //get all fav products
        [HttpGet, Route("GetAllFavouriteProducts/{userId}")]
        public IActionResult GetAllFavProducts([FromRoute]  int userId)
        {
            //var user = HttpContext.User;
            //int localUserId = user.Identity.Name;
            try
            {
                List<Product> favProducts = _favouritesService.GetAllFavProducts(userId);
                if (favProducts != null)
                {
                    return StatusCode(200, favProducts);
                }
                return StatusCode(400, new JsonResult("no fav products found"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
