using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
using DAL;

namespace LOGIC
{
    class UserController
    {
        UserDAL userdal = new UserDAL();


        public User GetUserByName(string name)
        {
            
            UserModel userModel = userdal.GetUserByName(name);

            User user = new User(userModel.userID,userModel.name, userModel.telNr,userModel.username,userModel.password,userModel.lvl);

            return (user);
        }

        public void AddUser(UserModel userModel)
        {
            User user = GetUserByName(userModel.name);


        }
    }
}
