using MVC5Course.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [Authorize]
    [自訂ActionFilter記錄所有程式時間]
    [自訂ActionFilterTest]
    public abstract class BaseController : Controller
    {

        protected override void HandleUnknownAction(string actionName)
        {
           // this.Redirect("/").ExecuteResult(this.ControllerContext);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)

        { 

            base.OnActionExecuting(filterContext);
        }

    
    }
}