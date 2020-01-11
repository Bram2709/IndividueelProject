using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Table;
using MySql.Data.MySqlClient;
using MODEL.Reservation;

namespace DAL
{
    public class TableDAL : ITableDAL
    {
        private string connString = "server=localhost;database=reserveringssysteem;user=root;password=;";

        MySqlConnection DbCon;

        List<TableModel> ITableDAL.GetAllTables()
        {
            throw new NotImplementedException();
        }

        public bool IsThereAnAvailibleTalbe(ReservationModel reservation)
        {
            List<TableModel> tableModels = new List<TableModel>();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "SELECT * FROM `table` WHERE `forThisAmountOfPeaple` = '"+reservation.amountOfPeaple+ "'";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                DbCon.Close();
                return true;

            }
            else
            {
                DbCon.Close();
                return false;
            }
            
        }

        public void AddReservationToTable(ReservationModel reservation)
        {
            TableModel tableToUpdate = new TableModel();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "SELECT * FROM `table` WHERE `forThisAmountOfPeaple` = '"+reservation.amountOfPeaple+"' AND `ReservationID` IS NULL LIMIT 1";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                tableToUpdate.tableID = Convert.ToInt32(dataReader["TableID"]);
                
            }

            dataReader.Close();
            string query2 = "UPDATE `table` SET `ReservationID`='"+ reservation.ReservationID + "' WHERE `TableID` = '"+tableToUpdate.tableID+"'";

            MySqlCommand command2 = new MySqlCommand(query2, DbCon);
            MySqlDataReader dataReader2 = command2.ExecuteReader();

            DbCon.Close();

        }

    }
}
