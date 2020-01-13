using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL.Reservation
{
    public interface IReservationController
    {
        List<ReservationModel> GetAll();
        void AddReservation(ReservationModel reservation);
    }
}
