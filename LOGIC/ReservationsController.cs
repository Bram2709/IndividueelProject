﻿using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Reservation;
using DAL;
using MODEL.Restaurant;
using System.Text.RegularExpressions;
using MODEL.Table;
using MODEL.AdvancedModels;

namespace LOGIC
{
    public class ReservationsController
    {
        ReservationDAL reservationDAL = new ReservationDAL();
        TableDAL tableDAL = new TableDAL();

        public List<ReservationModel> GetAll()
        {
            var reservations = reservationDAL.GetAll();
            return reservations;
        }

        public void AddReservation(ReservationModel reservation)
        {
            reservationDAL.AddReservation(reservation);
        }

        public bool TryToAddReservation(ReservationModel reservation, RestaurantModel restaurant)
        {
            if (tableDAL.IsThereAnAvailibleTalbe(reservation) == false)
            {
                return false;
            }
            else
            {
                if (reservation.amountOfPeaple < restaurant.maxAmountOfPeaple - restaurant.CurrentAmountOfPeaple)
                {               
                    //checks voor het minvullen van geldige gegevens
                    if (reservation.Name == "")
                    {
                        return false;
                    }
                    else if (reservation.date < DateTime.Now)
                    {
                        return false;
                    }
                    else
                    {
                        AddReservation(reservation);
                        ReservationModel reservationModel = reservationDAL.getReservation(reservation);
                        tableDAL.AddReservationToTable(reservationModel);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        public List<AllReservationData> GetAllReservationData()
        {
            return reservationDAL.GetAllReservationData();
        }
    }
}
