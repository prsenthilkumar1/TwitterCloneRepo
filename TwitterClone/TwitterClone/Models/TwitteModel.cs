using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class TwitteModel
    {
        public string User_ID { get; set; }
        public string TweetContent { get; set; }
        public DateTime TweetCreate { get; set; }
        public List<TwitteDetailModel> TwitteDetail { get; set; }
    }
}