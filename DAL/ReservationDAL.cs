using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Reservation;
using System.Data.SqlClient;
using System.Data;

using MySql.Data.MySqlClient;


namespace DAL
{
    public class ReservationDAL : IReservationDAL
    {
        private string connString = "server=localhost;database=reserveringssysteem;user=root;password=;";

        MySqlConnection DbCon;

        public List<ReservationModel> GetAll()
        {
            List<ReservationModel> resrvationModels = new List<ReservationModel>();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "SELECT * FROM reservering";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                ReservationModel reservationModel = new ReservationModel();

                reservationModel.ReservationID = Convert.ToInt32(dataReader["ReserveringID"]);
                reservationModel.Name = dataReader["Naam"].ToString();
                reservationModel.date = (DateTime)dataReader["Datum"];
                reservationModel.telNr = dataReader["TelNr"].ToString();
                reservationModel.amountOfPeaple = Convert.ToInt32(dataReader["AantalPersonen"]);
                reservationModel.note = dataReader["Opmerkingen"].ToString();


                resrvationModels.Add(reservationModel);
            }

            DbCon.Close();

            return resrvationModels;
        }

        public void AddReservation(ReservationModel reservation)
        {
            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string format = "yyyy-MM-dd HH:mm:ss";

            string query = "INSERT INTO `reservering`(`Naam`,`Datum`,`TelNr`, `AantalPersonen`, `Opmerkingen`) " +
                "VALUES ('" + reservation.Name + "','" + reservation.date.ToString(format) + "','" + reservation.telNr + "','" + reservation.amountOfPeaple + "','" + reservation.note + "')";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            DbCon.Close();
        }

        public ReservationModel getReservation(ReservationModel reservation)
        {
            ReservationModel resrvationModel = new ReservationModel();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "SELECT `ReserveringID`, `Naam`, `Datum`, `TelNr`, `AantalPersonen`, `Opmerkingen` FROM `reservering` " +
                "WHERE `Naam` = '"+reservation.Name+ "' AND `AantalPersonen`= '" + reservation.amountOfPeaple + "'";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                resrvationModel.ReservationID = Convert.ToInt32(dataReader["ReserveringID"]);
                resrvationModel.Name = dataReader["Naam"].ToString();
                resrvationModel.date = (DateTime)dataReader["Datum"];
                resrvationModel.telNr = dataReader["TelNr"].ToString();
                resrvationModel.amountOfPeaple = Convert.ToInt32(dataReader["AantalPersonen"]);
                resrvationModel.note = dataReader["Opmerkingen"].ToString();

            }

            DbCon.Close();

            return resrvationModel;

        }
    }
}
