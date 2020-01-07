using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Reservation;
using DAL;

namespace LOGIC
{
    public class ReservationsController
    {
        ReservationDAL reservationDAL = new ReservationDAL();

        public List<ReservationModel> GetAll()
        {
            var reservations = reservationDAL.GetAll();
            return reservations;
        }

        public void AddReservation(ReservationModel reservation)
        {
            reservationDAL.AddReservation(reservation);
        }

    }
}
