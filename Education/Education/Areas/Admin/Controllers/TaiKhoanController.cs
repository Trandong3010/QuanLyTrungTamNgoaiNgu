using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
		UsersDAO dao = new UsersDAO();
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		// GET: Admin/TaiKhoan
		public ActionResult Index()
        {
			var users = dao.GetList();
			ViewBag.users = users;
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
			return Json(new { data = users }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Save(User item)
		{
			bool status = false;
			dao.Save(item);
			return new JsonResult{ Data = new {status = status } };

		}


	}
}