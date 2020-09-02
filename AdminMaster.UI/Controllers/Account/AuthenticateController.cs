using System;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace AdminMaster.UI.Controllers.Account
{
    public class AuthenticateController : Controller
    {
        // GET: Authenticate
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            UserViewModel model = GetUserViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(string username, string password, string remember)
        {
            if (username.ToLower() != "admin" || password != "123456")
            {
                return View();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(remember) && remember == "true")
                {
                    string user = $"{ username},{password},{remember}";
                    HttpCookie cookie = new HttpCookie("userkey")
                    {
                        Value = user,
                        Expires = DateTime.Now.AddMinutes(5)
                    };
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("userkey")
                    {
                        Expires = DateTime.Now.AddMinutes(-5)
                    };
                    Response.Cookies.Add(cookie);
                }
                Session["CurrentUser"] = new UserViewModel
                {
                    UserName = username,
                    PassWord = password,
                    IsRemember = !string.IsNullOrWhiteSpace(remember) && remember == "true" ? true : false
                };
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Logout()
        {
            Session["CurrentUser"] = null;
            UserViewModel model = GetUserViewModel();
            return View("Login", model);
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string username, string password, string newPassword)
        {
            return View();
        }
        private UserViewModel GetUserViewModel()
        {
            string userInfo = string.Empty;
            UserViewModel model = new UserViewModel();
            if (Request.Cookies["userkey"] != null && Request.Cookies["userkey"].Value != null)
            {
                userInfo = Request.Cookies["userkey"].Value;
            }
            if (!string.IsNullOrWhiteSpace(userInfo))
            {
                string[] arr = userInfo.Split(',');
                if (arr.Length == 3 && arr[2] == "true")
                {
                    model.UserName = arr[0];
                    model.PassWord = arr[1];
                    model.IsRemember = true;
                }
            }
            return model;
        }
    }
}