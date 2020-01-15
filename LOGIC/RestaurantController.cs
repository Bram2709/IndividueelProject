using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using MODEL.Restaurant;

namespace LOGIC
{
    public class RestaurantController
    {
        RestaurantDAL restaurantDAL = new RestaurantDAL();
        public List<RestaurantModel> GetAll()
        {
            restaurantDAL = new RestaurantDAL();

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


        public RestaurantModel GetRestaurantModelByName(string name)
        {
            var x = restaurantDAL.GetRestaurantByName(name);
            return x;
        }

        

        public int GetAvaliblePlaces(string restaurant)
        {
            RestaurantModel restaurantModel = restaurantDAL.GetRestaurantByName(restaurant);

            return restaurantModel.maxAmountOfPeaple - restaurantDAL.GetCurrentAmountOfPeapleInRestaurant(restaurantModel);
        }
    }
}
