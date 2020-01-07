using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Reservation;
using DAL;

namespace LOGIC
{
    public class Reservation
    {
        ReservationDAL reservationDAL = new ReservationDAL();

        public void EditReservation(ReservationModel reservation)
        {
            //reservationDAL.EditReservation(reservation);
        }
    }
}
