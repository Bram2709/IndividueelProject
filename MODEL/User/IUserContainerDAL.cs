using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public interface IUserContainerDAL
    {
        List<UserModel> GetAll();
        UserModel GetUserByName(string username);
        
    }
}
