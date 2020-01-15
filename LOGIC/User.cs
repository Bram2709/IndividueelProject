using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using MODEL;


namespace LOGIC
{
    public class User
    {
        UserDAL userDAL = new UserDAL();
        public void EditUser(UserModel user)
        {
            userDAL.EditUser(user);
        }

        public bool LoginCheck(string username, string password)
        {
            UserModel thisUser = userDAL.GetUserByUserName(username);

            if (thisUser.username == username && thisUser.password == password && thisUser.username != null)
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
