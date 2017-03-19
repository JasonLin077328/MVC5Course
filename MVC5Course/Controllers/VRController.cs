using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class VRController : BaseController
    {
        // GET: VR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult File1()
        {
            return File(Server.MapPath(@"~\Content\images.jpg"), "image/jpg");
        }
        public ActionResult File2()
        {            
            return File(Server.MapPath(@"~\Content\images.jpg"), "image/jpg","檔案下載.JPG");
        }


        public ActionResult Content1()
        {
            return Content("@@");
        }
    }
}