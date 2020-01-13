using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL.Restaurant
{
    public interface IRestaurantController
    {
        List<RestaurantModel> GetAll();
        RestaurantModel GetRestaurantByName(string restaurantName);
        void AddRestaurant(RestaurantModel restaurant);
    }
}
