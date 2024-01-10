using Microsoft.AspNetCore.Mvc;
using projectDB.Entities;
using projectDB.Models;
using System.Runtime.Intrinsics.Arm;

namespace projectDB.Services
{
    public class FavouritesService:IFavouritesService
    {
        private readonly CaseStudyDbContext _favDBcontext;

        public FavouritesService(CaseStudyDbContext favDBcontext)
        {
            _favDBcontext = favDBcontext;
        }

        //Added to fav products
        public Boolean AddToFav(FavProducts product)
        {
            try
            {
                //to get user
                User user = _favDBcontext.Users.FirstOrDefault(e => e.UserId==product.UserId);
                if (user!=null)
                {
                    FavProducts dupFav = (from f in _favDBcontext.FavOrderItems where f.ProductId == product.ProductId select f).FirstOrDefault(e => e.UserId == product.UserId);
;
         
                    if (dupFav == null) //add to favorites 
                    {
                        _favDBcontext.FavOrderItems.Add(product);
                        _favDBcontext.SaveChanges();
                        return true;
                    }
                    else //if there is a existing product remove it from main page
                    {
                        _favDBcontext.FavOrderItems.Remove(dupFav);
                        _favDBcontext.SaveChanges();
                    }
                    return false;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
           
           
        }

        public Boolean RemoveFromFav(FavProducts product)
        {
            try
            {

                //to get user
                //User user = _favDBcontext.Users.FirstOrDefault(e => e.UserId == product.UserId);
                User user = _favDBcontext.Users.FirstOrDefault(e => e.UserId == product.UserId);
                if(user!=null)
                {
                    FavProducts prod = (from f in _favDBcontext.FavOrderItems where f.ProductId == product.ProductId select f).FirstOrDefault(e => e.UserId == product.UserId);
                    if (prod != null)
                    {
                        Console.WriteLine($"Remoing producit : productId : {prod.ProductId}    userId: {prod.UserId}");
                        _favDBcontext.FavOrderItems.Remove(prod);
                        _favDBcontext.SaveChanges();
                        return true;
                    }
                } 
                return false;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FavProducts GetFavProduct(int id)
        {
            return _favDBcontext.FavOrderItems.Find(id);
        }
        public List<Product> GetAllFavProducts(int userId)
        {
            //used inner join (common elements were taken out in favOrderItems and Products)
            //if(userId > 0)
            //{
                List<Product> favProducts = (from p in (from f in _favDBcontext.FavOrderItems
                                                        where f.UserId == userId
                                                        select f)
                                             join pp in _favDBcontext.Products on p.ProductId equals pp.ProductId
                                             select pp).ToList();
                return favProducts;
            //}
            //return null;  
        }

        //public Boolean dupCeck(FavProducts dup)
        //{
        //    User user = _favDBcontext.Users.FirstOrDefault(e => e.UserId == dup.UserId);
        //    if (user != null)
        //    {
        //        var dupFav = from d in _favDBcontext.FavOrderItems
        //                         where d.UserId == dup.UserId && d.Equals(dup) select d;

        //        Console.WriteLine("dup element :",dupFav);
        //        if (dupFav!=null)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

    }
}
