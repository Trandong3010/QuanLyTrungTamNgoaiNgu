using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Controllers
{
	public class Home_Controller : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

	}
}