using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Reservation;
using MODEL.Restaurant;

namespace MODEL.AdvancedModels
{
    public class ReservationEmptyReservationRestaurantModel
    {
        public ReservationModel reservationFull { get; set; }
        public ReservationModel reservationEmpty { get; set; }
        public List<string> restaurant { get; set; }
    }
}
