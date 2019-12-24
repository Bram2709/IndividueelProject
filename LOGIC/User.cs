using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC
{
    public class User
    {
        private int userID;
        private string name;
        private string telNr;
        private string username;
        private string password;
        private int lvl;

        public User()
        {

        }

        public User(int _userID, string _name, string _telNr, string _username, string _password, int _lvl)
        {
            _userID = userID;
            _name = name;
            _telNr = telNr;
            _username = username;
            _password = password;
            _lvl = lvl;
        }

    }
}
