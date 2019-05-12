using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
	public class TaiKhoanController : BaseController
	{
		UsersDAO dao = new UsersDAO();
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		// GET: Admin/TaiKhoan
		public ActionResult Index()
		{
			var Id = Session["IDUser"].ToString();
			var IDPermision = dao.GetByIDPermision(int.Parse(Id)).ToString();
			var Permision = dao.GetPermision(int.Parse(IDPermision));
			ViewBag.Permision = Permision;
			return View();
		}

		public JsonResult GetUsers()
		{
			var users = dao.GetList();
			return Json(new { data = users }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetUsersById(int id)
		{
			var users = dao.GetUserById(id);
			return Json(users, JsonRequestBehavior.AllowGet);
		}


		public ActionResult Save(User item)
		{
			bool status = false;
			dao.Save(item);
			return new JsonResult { Data = new { status = status } };

		}

		public JsonResult Delete(int id)
		{
			var lst = dao.Delete(id);
			return Json(lst, JsonRequestBehavior.AllowGet);
		}

		public ActionResult ShowProfile()
		{
			return View();
		}

		public JsonResult ProfileInfo()
		{
			var Id = Session["IDUser"].ToString();
			var lst = dao.Profile(int.Parse(Id));
			return Json(lst, JsonRequestBehavior.AllowGet);
		}

	}
}