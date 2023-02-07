﻿using CursoCoder.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1;

namespace CursoCoder.Controller
{
    internal class LoginController
    {
        public static string LogIn(string userName, string userPassword)
        {
            string sResult = "";

            sResult = Program.sqlHandler.LoginUser(userName, userPassword) == true ? "Login successful" : "Login failed";

            return sResult;
        }
    }
}
