using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers.Trangchu
{
	public class TrangChuController : BaseController
    {
		// GET: Admin/TrangChu
		[NoCache]
		public ActionResult Index()
        {
				return View();
			
		}
	}
}