using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers.Phanquyen
{
    public class PermisionController : Controller
    {
        // GET: Admin/Permision
        public ActionResult Index()
        {
			if (Session["Username"].ToString() != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}


    }
}