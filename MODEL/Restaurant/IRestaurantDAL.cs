using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL.Restaurant
{
    public interface IRestaurantDAL
    {
        List<RestaurantModel> GetAll();
    }
}
