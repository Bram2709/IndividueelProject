using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL.Reservation
{
    public interface IReservationDAL
    {
        void EditReservation(ReservationModel reservation);
    }
}
