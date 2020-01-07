using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL.Reservation
{
    public class ReservationModel
    {
        public int ReservationID { get; set; }
        public string Name { get; set; }
        public DateTime date { get; set; }
        public string telNr { get; set; }
        public int amountOfPeaple { get; set; }
        public string note { get; set; }
        public string restaurant { get; set; }
    }
}
