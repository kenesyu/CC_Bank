using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.ClsLib
{
    public class UserList
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }
        public List<User> userlist { get; set; }
    }


    public class User
    {
        public string userid { get; set; }
        public string name { get; set; }
        public string[] department { get; set; }
    }
}