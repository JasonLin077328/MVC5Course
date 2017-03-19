using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ErrorController : BaseController
    {
        [HandleError(View = "Errer_AggregateException", ExceptionType =typeof(AggregateException))]
        [HandleError(View = "Errer_OutOfMemoryException", ExceptionType =typeof(OutOfMemoryException))]
        [HandleError(View = "Errer_ArrayTypeMismatchException",ExceptionType =typeof(ArrayTypeMismatchException))]
        public ActionResult Index(int i = 0 )
        {
            switch (i)
            {
                case 1:
                    throw new Exception("Error ....................Exception");
                         case 2:
                    throw new AggregateException("Error ....................AggregateException");
                         case 3:
                    throw new OutOfMemoryException("Error ....................OutOfMemoryException");
                         case 4:
                    throw new ArrayTypeMismatchException("Error ....................OutputCacheAttribute");
                        default:
                    break;
            }
            return View();
        }
    }
}