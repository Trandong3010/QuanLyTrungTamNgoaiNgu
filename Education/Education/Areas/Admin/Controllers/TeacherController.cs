using Education.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    public class TeacherController : BaseController
    {
        TeacherDAO dao = new TeacherDAO();

        [HttpPost]
        public JsonResult GetList()
        {
            var lst = dao.GetList();
            return Json(new {data = lst }, JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/Teacher
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
		[HttpPost]
		public JsonResult GetTeacherById(int id)
		{
			var lst = dao.GetTeacherById(id);
			return Json(lst, JsonRequestBehavior.AllowGet);
		}
	}
}