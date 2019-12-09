using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
using System.Data.SqlClient;
using System.Data;

using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserDAL : IUserContainerDAL,IUserDAL
    {
        private string connString = "server=localhost;database=reserveringssysteem;user=root;password=;";

        MySqlConnection DbCon;

        public UserModel GetAll()
        {
            UserModel userModel = new UserModel();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "SELECT * FROM reservering";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                userModel.username = dataReader["ReserveringID"].ToString();
                userModel.password = dataReader["Naam"].ToString();
            }

            DbCon.Close();

            return userModel;
        }

        public UserModel GetUserByName(string username)
        {
            UserModel userModel = new UserModel();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "SELECT * FROM users WHERE Username == " + username + "";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                userModel.username = dataReader["ID"].ToString();
                userModel.username = dataReader["Name"].ToString();
                userModel.username = dataReader["TelNr"].ToString();
                userModel.username = dataReader["Username"].ToString();
                userModel.password = dataReader["Password"].ToString();
                userModel.lvl = Convert.ToInt32(dataReader["Lvl"]);
            }

            DbCon.Close();

            return userModel;
        }

        
        public void AddUser(UserModel user)
        {
            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "INSERT INTO `users`(`Name`,`TelNr`,`Username`, `Password`, `Lvl`) " +
                "VALUES ('" + user.name + "','" + user.telNr + "','" + user.username + "','" + user.password + "','"+user.lvl+"')";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            DbCon.Close();

           
        }


    }
}
