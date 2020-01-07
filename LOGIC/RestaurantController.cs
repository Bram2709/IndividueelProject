using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using MODEL.Restaurant;

namespace LOGIC
{
    public class RestaurantController
    {
        public List<RestaurantModel> GetAll()
        {
            RestaurantDAL restaurantDAL = new RestaurantDAL();

            var allRestaurants = restaurantDAL.GetAll();
            return allRestaurants;
        }

        public List<string> GetAllRestaurantNames()
        {
            var all = this.GetAll();
            List<string> restaurantNames = new List<string>();


            foreach (var item in all)
            {
                restaurantNames.Add(item.restaurantName);
            }
            return restaurantNames;
        }

        //public RestaurantModel GetRestaurant()
        //{

        //}

    }
}
