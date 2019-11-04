using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterClone.Models;

namespace TwitterClone.DataAccessLayer
{
    public class DataEntity
    {
        public bool UserLogin(LoginModel LoginModel)
        {
            bool isValidUser = false;

            using (var context = new TwitterEntities())
            {
                isValidUser = context.People.Any(t => t.user_id.ToLower() == LoginModel.User_ID.ToLower() && t.password == LoginModel.Password);
            }
            return isValidUser;
        }

        public UserModel UserDetails(LoginModel LoginModel)
        {
            UserModel UserModel = new UserModel();

            using (var context = new TwitterEntities())
            {
                var user = context.People.Where(t => t.user_id.ToLower() == LoginModel.User_ID.ToLower() && t.password == LoginModel.Password).Select(t => t).FirstOrDefault();
                if (user != null)
                {
                    UserModel = new UserModel()
                    {
                        User_ID = user.user_id,
                        Password = user.password,
                        FullName = user.fullname,
                        Email = user.email,
                        Joined = user.joined,
                        ActiveInd = user.active
                    };
                }
            }
            return UserModel;
        }

        public TwitteModel TwitteDetails(string User_ID)
        {
            TwitteModel TwitteModel = new TwitteModel();
            TwitteModel.TwitteDetail = new List<TwitteDetailModel>();

            using (var context = new TwitterEntities())
            {
                List<string> follows = new List<string>();
                List<TWEET> l_twittes = new List<TWEET>();
                
                follows = context.FOLLOWINGs.Where(t => t.user_id.ToLower() == User_ID.ToLower()).Select(x => x.following_id).ToList();
                follows.Add(User_ID);
                var twittes = context.TWEETs.Select(t => t).ToList();

                foreach (var item in follows)
                {
                    var twitte = context.TWEETs.Where(t => t.user_id.ToLower() == item.ToLower()).Select(t => t).ToList();
                    if (twitte != null)
                    {
                        l_twittes.AddRange(twitte);
                    }
                }

                if (l_twittes != null)
                {                    
                    foreach (var item in l_twittes.OrderByDescending(t=>t.tweet_id))
                    {
                        TwitteDetailModel TwitteDetailModel = new TwitteDetailModel()
                        {
                            Message = item.message,
                            MessageCreateTime = Convert.ToDateTime(item.created),
                            User_ID = item.user_id,
                            TwittedID = item.tweet_id
                        };
                        TwitteModel.TwitteDetail.Add(TwitteDetailModel);
                    }                    
                }
            }
            return TwitteModel;
        }

        public bool SaveUser(UserModel UserModel)
        {
            bool isSave = false;

            using (var context = new TwitterEntities())
            {
                PERSON l_person = new PERSON()
                {
                    user_id = UserModel.User_ID,
                    password = UserModel.Password,
                    fullname = UserModel.FullName,
                    email = UserModel.Email,
                    joined = UserModel.Joined,
                    active = UserModel.ActiveInd
                };

                context.People.Add(l_person);
                context.SaveChanges();

                isSave = true;
            }
            return isSave;
        }

        public bool SaveTweet(TwitteModel TwitteModel)
        {
            bool isSave = false;

            using (var context = new TwitterEntities())
            {
                TWEET l_tweet = new TWEET()
                {
                    user_id = TwitteModel.User_ID,
                    message = TwitteModel.TweetContent,
                    created = TwitteModel.TweetCreate
                };

                context.TWEETs.Add(l_tweet);
                context.SaveChanges();

                isSave = true;
            }
            return isSave;
        }
    }
}