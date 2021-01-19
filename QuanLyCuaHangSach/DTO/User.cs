using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class User
    {
        string userName;
        string passWord;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
    }
}