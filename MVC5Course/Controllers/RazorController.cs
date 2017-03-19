using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class RazorController : Controller
    {
        // GET: Razer
        public ActionResult Index()
        {
            int[] data = { 1, 2, 3, 4, 5 };
            return PartialView(data);
        }
    }
}