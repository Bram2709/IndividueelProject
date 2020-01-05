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

            UserModel userModel = userdal.GetUserByName(name);



            return (userModel);
        }

        //public void AddUser(UserModel userModel)
        //{
        //    User user = GetUserByName(userModel.name);
        //}
    }
}
