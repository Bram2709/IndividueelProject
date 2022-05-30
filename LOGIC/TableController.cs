using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Table;
using MODEL.Restaurant;
using DAL;

namespace LOGIC
{
    public class TableController
    {
        public bool AddTable(TableModel table)
        {
            RestaurantController restaurantController = new RestaurantController();
            List<RestaurantModel> restaurantModel = restaurantController.GetAll();
            bool restaurantExists = false;

            foreach (var item in restaurantModel)
            {
                if (item.restaurantID == table.restaurantID)
                {
                    restaurantExists = true;
                }
            }
            if (restaurantExists)
            {
                TableDAL tableDAL = new TableDAL();
                tableDAL.AddTable(table);
                return true;
            }
            else
            {
                return false;
            }

            
            

        }

    }
}
