using Microsoft.AspNetCore.Mvc;
using projectDB.Entities;
using projectDB.Models;

namespace projectDB.Services
{
    public interface IFavouritesService
    {
        //methods
        Boolean AddToFav(FavProducts product);

        
        Boolean RemoveFromFav(FavProducts item);
        List<Product> GetAllFavProducts(int userId);

        FavProducts GetFavProduct(int id);

        //Boolean dupCeck(FavProducts dup);
    }
}
