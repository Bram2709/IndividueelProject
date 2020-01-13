using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Table;
using MODEL.Restaurant;

namespace MODEL
{
    public class RestaurantAndTableModel
    {
        public TableModel tableModel { get; set; }
        public List<RestaurantModel> restaurantModels { get; set; }
    }
}
