using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL.Reservation
{
    public interface IReservationDAL
    {
        List<ReservationModel> GetAll();
        void AddReservation(ReservationModel reservation);
    }
}
