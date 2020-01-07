using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MODEL.Restaurant;
using MODEL.Reservation;

namespace MODEL
{
    public class RestaurantAndReserveringModel
    {
        public List<RestaurantModel> Restaurants { get; set; }
        public List<ReservationModel> Reserveringen { get; set; }
    }
}
