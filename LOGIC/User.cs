using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC
{
    public class User
    {
        private int id = 0;
        private string name = "";
        private string telNr = "";
        private string username = "";
        private string password = "";
        private int lvl = 0;

        public User(int _id, string _name, string _telNr, string _username, string _password, int _lvl)
        {
            _id = id;
            _name = name;
            _telNr = telNr;
            _username = username;
            _password = password;
            _lvl = lvl;
        }
    }
}
