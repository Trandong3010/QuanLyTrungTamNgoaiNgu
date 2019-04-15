using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers.Trangchu
{
    public class TrangChuController : Controller
    {
        // GET: Admin/TrangChu
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
			//return View();
		}
	}
}