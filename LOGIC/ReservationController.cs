using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Reservation;
using DAL;

namespace LOGIC
{
    public class ReservationController
    {
        public List<ReservationModel> GetAll()
        {
            ReservationDAL reservationDAL = new ReservationDAL();
            var reservations = reservationDAL.GetAll();
            return reservations;
        }
    }
}
