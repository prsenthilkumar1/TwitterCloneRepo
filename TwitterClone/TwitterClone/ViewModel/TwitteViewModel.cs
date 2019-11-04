using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.ViewModel
{
    public class TwitteViewModel
    {
        public string User_ID { get; set; }
        public string TweetContent { get; set; }
        public DateTime TweetCreate { get; set; }
        public bool isTweetSave { get; set; }
        public List<TwitteDetailViewModel> TwitteDetail { get; set; }
    }
}