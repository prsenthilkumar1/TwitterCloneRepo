using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterClone.ViewModel;
using TwitterClone.Models;
using TwitterClone.DataAccessLayer;

namespace TwitterClone.BusinessLayer
{
    public class BusinessEntity
    {
        public bool UserLogin(LoginViewModel LoginViewModel)
        {
            bool isValidUser = false;
            DataEntity l_DataEntity = new DataEntity();

            LoginModel LoginModel = new LoginModel()
            {
                User_ID = LoginViewModel.User_ID,
                Password = LoginViewModel.Password
            };

            isValidUser = l_DataEntity.UserLogin(LoginModel);
            return isValidUser;
        }
        public bool SaveUser(UserViewModel UserViewModel)
        {
            bool isSave = false;
            DataEntity l_DataEntity = new DataEntity();

            UserModel UserModel = new UserModel()
            {
                User_ID = UserViewModel.User_ID,
                Password = UserViewModel.Password,
                FullName = UserViewModel.FullName,
                Email = UserViewModel.Email,
                Joined = UserViewModel.Joined,
                ActiveInd = UserViewModel.ActiveInd
            };

            l_DataEntity.SaveUser(UserModel);
            return isSave;
        }

        public UserViewModel UserDetails(LoginViewModel LoginViewModel)
        {
            UserViewModel UserViewModel = new UserViewModel();
            DataEntity l_DataEntity = new DataEntity();

            LoginModel LoginModel = new LoginModel()
            {
                User_ID = LoginViewModel.User_ID,
                Password = LoginViewModel.Password
            };

            var userDetails = (UserModel)l_DataEntity.UserDetails(LoginModel);
            if (userDetails!=null)
            {
                UserModel UserModel = new UserModel();
                UserModel = (UserModel)userDetails;

                UserViewModel = new UserViewModel()
                {
                    User_ID = UserModel.User_ID,
                    Password = UserModel.Password,
                    FullName = UserModel.FullName,
                    Email = UserModel.Email,
                    Joined = UserModel.Joined,
                    ActiveInd = UserModel.ActiveInd,
                    isValidUser= LoginViewModel.isValidUser
                };
            }
            return UserViewModel;
        }

        public bool SaveTweet(TwitteViewModel TwitteViewModel)
        {
            bool isSave = false;
            DataEntity l_DataEntity = new DataEntity();

            TwitteModel TwitteModel = new TwitteModel()
            {
                User_ID = TwitteViewModel.User_ID,
                TweetContent = TwitteViewModel.TweetContent,
                TweetCreate = TwitteViewModel.TweetCreate
            };

            l_DataEntity.SaveTweet(TwitteModel);
            return isSave;
        }

        public TwitteViewModel TwitteDetails(string User_ID)
        {
            TwitteViewModel TwitteViewModel = new TwitteViewModel();
            TwitteViewModel.TwitteDetail = new List<TwitteDetailViewModel>();
            DataEntity l_DataEntity = new DataEntity();

            var twittes = l_DataEntity.TwitteDetails(User_ID);
            if (twittes != null)
            {
                foreach (var item in twittes.TwitteDetail)
                {
                    TwitteDetailViewModel TwitteDetailViewModel = new TwitteDetailViewModel()
                    {
                        TwittedID = item.TwittedID,
                        User_ID = item.User_ID,
                        Message = item.Message,
                        MessageCreateTime = item.MessageCreateTime
                    };
                    TwitteViewModel.TwitteDetail.Add(TwitteDetailViewModel);
                }
            }
            return TwitteViewModel;
        }
    }
}