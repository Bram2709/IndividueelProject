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

            string query = "SELECT * FROM users";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                ReservationModel reservationModel = new ReservationModel();

                reservationModel.ReservationID = Convert.ToInt32(dataReader["ReserveringID"]);
                reservationModel.Name = dataReader["Name"].ToString();
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
    }
}
