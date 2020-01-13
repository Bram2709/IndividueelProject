using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MODEL.Restaurant;
using MODEL.Reservation;

namespace MODEL
{
    public class RestaurantAndEmptyReserveringModel
    {
        public List<string> Restaurants { get; set; }
        public ReservationModel Reserveringen { get; set; }
    }
}
