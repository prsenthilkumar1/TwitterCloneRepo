using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.BusinessLayer;
using TwitterClone.Models;
using TwitterClone.ViewModel;

namespace TwitterClone.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult UserLogin(LoginViewModel LoginViewModel)
        {
            bool isValidUser = false;
            UserViewModel UserViewModel = new UserViewModel();
            BusinessEntity l_BusinessEntity = new BusinessEntity();
            LoginViewModel.isValidUser = l_BusinessEntity.UserLogin(LoginViewModel);

            if (LoginViewModel.isValidUser)
            {
                UserViewModel = l_BusinessEntity.UserDetails(LoginViewModel);
            }

            return Json(UserViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult CreateNewAccount(UserViewModel UserViewModel)
        {
            bool isSave = false;
            BusinessEntity l_BusinessEntity = new BusinessEntity();
            UserViewModel.Joined = DateTime.Now;
            l_BusinessEntity.SaveUser(UserViewModel);
            return View("CreateAccount");
        }

        public ActionResult MyTwitterClone(string User_ID)
        {
            UserViewModel UserViewModel = new UserViewModel();
            BusinessEntity l_BusinessEntity = new BusinessEntity();
            UserViewModel.User_ID = User_ID;
            UserViewModel.TwitteViewModel = new TwitteViewModel();
            UserViewModel.TwitteViewModel.User_ID = UserViewModel.User_ID;

            UserViewModel.TwitteViewModel.TwitteDetail = new List<TwitteDetailViewModel>();
            UserViewModel.TwitteViewModel = l_BusinessEntity.TwitteDetails(UserViewModel.User_ID);

            return View("MyTwitterClone",UserViewModel);
        }
        public ActionResult Home(UserViewModel UserViewModel)
        {
            return View();
        }
        public ActionResult Profile(UserViewModel UserViewModel)
        {
            return View();
        }
        public ActionResult SignOut(UserViewModel UserViewModel)
        {
            return View("Login");
        }
        public ActionResult FollowPage(UserViewModel UserViewModel)
        {
            return View("FollowPage", UserViewModel);
        }
        public ActionResult Twitte(TwitteViewModel TwitteViewModel)
        {
            BusinessEntity l_BusinessEntity = new BusinessEntity();
            TwitteViewModel.TwitteDetail = new List<TwitteDetailViewModel>();
            TwitteViewModel = l_BusinessEntity.TwitteDetails(TwitteViewModel.User_ID);
            return View("Twitte", TwitteViewModel);
        }

        public ActionResult TwitteSave(TwitteViewModel TwitteViewModel)
        {            
            BusinessEntity l_BusinessEntity = new BusinessEntity();
            TwitteViewModel.TweetCreate = DateTime.Now;
            TwitteViewModel.isTweetSave = l_BusinessEntity.SaveTweet(TwitteViewModel);
            return View("Twitte", TwitteViewModel);
        }
    }
}