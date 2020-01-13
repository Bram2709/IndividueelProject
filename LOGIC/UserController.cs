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

        //public UserModel GetUserByUserName(string userName)
        //{
        //    UserModel userModel = userdal.GetUserByUserName(userName);

        //    return (userModel);
        //}

        public void AddUser(UserModel user)
        {
            userdal.AddUser(user);
        }

    }
}
