using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page. Test000123.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVM oLoginVM)
        {
            if (ModelState.IsValid)
            {
                TempData["LoginVM"] = oLoginVM;
                FormsAuthentication.RedirectFromLoginPage(oLoginVM.UserName,false);
                return Redirect("/Products/");
            }
            return Content("登入失敗");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Login");
        }
    }
}