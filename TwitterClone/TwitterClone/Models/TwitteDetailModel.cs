using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class TwitteDetailModel
    {
        public int TwittedID { get; set; }
        public string User_ID { get; set; }
        public string Message { get; set; }
        public DateTime MessageCreateTime { get; set; }
    }
}