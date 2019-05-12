using System;
using System.Web;
using System.Web.Mvc;
namespace Education.Areas.Admin.Controllers
{
	public class BaseController : Controller
    {
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var session = Session["Username"];
			if(session == null)
			{
				filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Login", action = "Index", Area = "Admin" }));
			}
			base.OnActionExecuting(filterContext);
		}
	}
}