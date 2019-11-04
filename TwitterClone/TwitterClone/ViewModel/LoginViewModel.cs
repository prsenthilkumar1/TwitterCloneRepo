using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.ViewModel
{
    public class LoginViewModel
    {
        public string User_ID { get; set; }
        public string Password { get; set; }
        public bool isValidUser { get; set; }
    }
}