using System;
using System.Web.Mvc;

namespace MVC5Course.ActionFilter
{
    public class 自訂ActionFilter記錄所有程式時間Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.StarDuraDate = DateTime.Now;
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.EndDuraDate = DateTime.Now;
            filterContext.Controller.ViewBag.DuraDate = filterContext.Controller.ViewBag.EndDuraDate - filterContext.Controller.ViewBag.StarDuraDate;
          
        }
    }
}