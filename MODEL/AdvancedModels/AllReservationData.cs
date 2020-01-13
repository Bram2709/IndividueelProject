using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Reservation;

namespace MODEL.AdvancedModels
{
    public class AllReservationData
    {
        public string reservationName { get; set; }
        public DateTime date { get; set; }
        public string telNr { get; set; }
        public int amountOfPeaple { get; set; }
        public string note { get; set; }
        public string restaurantName { get; set; }
    }
}
