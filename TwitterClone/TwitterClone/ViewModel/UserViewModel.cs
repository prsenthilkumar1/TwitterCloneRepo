using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.ViewModel
{
    public class UserViewModel
    {
        public string User_ID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Joined { get; set; }
        public bool ActiveInd { get; set; }
        public bool isValidUser { get; set; }
        public TwitteViewModel TwitteViewModel { get; set; }
    }
}