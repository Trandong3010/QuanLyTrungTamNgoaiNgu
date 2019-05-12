using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Education.Areas.Admin.Controllers
{
	public class SubjectController : BaseController
	{
		// GET: Admin/Subject
		SubjectDAO dao = new SubjectDAO();
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		public ActionResult Index()
		{
			return View();
		}


		public JsonResult GetSubject()
		{
			var subjects = dao.GetList();
			return Json(new { data = subjects }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetById(int id)
		{
			var item = dao.GetById(id);
			return Json(item, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Save(Subject item)
		{
			bool status = false;
			dao.Save(item);
			return new JsonResult { Data = new { status = status } };

		}

		public JsonResult Delete(int id)
		{
			Subject item = dao.GetById(id) as Subject;
			item.IsDelete = true;
			dao.Save(item);
			return Json(item, JsonRequestBehavior.AllowGet);
		}
	}
}