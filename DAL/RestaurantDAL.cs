using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Restaurant;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class RestaurantDAL : IRestaurantDAL
    {
        private string connString = "server=localhost;database=reserveringssysteem;user=root;password=;";

        MySqlConnection DbCon;

        public List<RestaurantModel> GetAll()
        {
            List<RestaurantModel> restaurantModels = new List<RestaurantModel>();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "SELECT * FROM restaurant";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                RestaurantModel restaurantModel = new RestaurantModel();

                restaurantModel.restaurantID = Convert.ToInt32(dataReader["RestaurantID"]);
                restaurantModel.restaurantName = dataReader["Name"].ToString();
                restaurantModel.restaurantAdres = dataReader["Adres"].ToString();
                restaurantModel.maxAmountOfPeaple = Convert.ToInt32(dataReader["MaxAmountOfPeaple"]);
                restaurantModel.CurrentAmountOfPeaple = Convert.ToInt32(dataReader["CurrentAmountOfPeaple"]);

                restaurantModels.Add(restaurantModel);
            }

            DbCon.Close();

            return restaurantModels;
        }

        public RestaurantModel GetRestaurantByName(string restaurantName)
        {
            RestaurantModel restaurantModel = new RestaurantModel();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "SELECT * FROM `restaurant` WHERE `Name` = '" + restaurantName+"'";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                restaurantModel.restaurantID = Convert.ToInt32(dataReader["RestaurantID"]);
                restaurantModel.restaurantName = dataReader["Name"].ToString();
                restaurantModel.restaurantAdres = dataReader["Adres"].ToString();
                restaurantModel.maxAmountOfPeaple = Convert.ToInt32(dataReader["MaxAmountOfPeaple"]);
                restaurantModel.CurrentAmountOfPeaple = Convert.ToInt32(dataReader["CurrentAmountOfPeaple"]);

            }
           

            DbCon.Close();

            return restaurantModel;
        }
    }
}
