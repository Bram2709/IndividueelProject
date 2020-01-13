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

        public List<UserModel> GetAll()
        {
            List<UserModel> userModels = new List<UserModel>();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();
             
            string query = "SELECT * FROM users";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                UserModel userModel = new UserModel();

                userModel.userID = Convert.ToInt32(dataReader["ID"]);
                userModel.name = dataReader["Name"].ToString();
                userModel.telNr = dataReader["TelNr"].ToString();
                userModel.username = dataReader["Username"].ToString();
                userModel.password = dataReader["Password"].ToString();
                userModel.lvl = Convert.ToInt32(dataReader["Lvl"]);


                userModels.Add(userModel);
            }

            DbCon.Close();

            return userModels;
        }

        public UserModel GetUserByUserName(string username)
        {
            UserModel userModel = new UserModel();

            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "SELECT * FROM users WHERE Username = '" + username + "'";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                userModel.userID = Convert.ToInt32(dataReader["ID"]);
                userModel.name = dataReader["Name"].ToString();
                userModel.telNr = dataReader["TelNr"].ToString();
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

        public void EditUser(UserModel user)
        {
            DbCon = new MySqlConnection(connString);
            DbCon.Open();

            string query = "UPDATE `users` SET `Name`='" + user.name + "',`TelNr`='" + user.telNr + "',`Username`='" + user.username + "'," +
                "`Password`='" + user.password + "' WHERE `ID` = '" + user.userID + "'";

            MySqlCommand command = new MySqlCommand(query, DbCon);
            MySqlDataReader dataReader = command.ExecuteReader();

            DbCon.Close();

        }
    }
}
