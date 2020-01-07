using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
using DAL;

namespace LOGIC
{
    public class UserController
    {
        UserDAL userdal = new UserDAL();

        public UserModel GetUserByName(string name)
        {
            UserModel userModel = userdal.GetUserByUserName(name);

            return (userModel);
        }

        public void AddUser(UserModel user)
        {
            userdal.AddUser(user);
        }

        public bool LoginCheck(string username, string password)
        {
            UserModel thisUser = userdal.GetUserByUserName(username);

            if (thisUser.username == username && thisUser.password == password)
            {
                //login is succesfull
                return true;
            }
            else
            {
                //login data incorrect
                return false;
            }

        }
    }
}
