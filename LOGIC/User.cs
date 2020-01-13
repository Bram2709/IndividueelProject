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
    }
}
