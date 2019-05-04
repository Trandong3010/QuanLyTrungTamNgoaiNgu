using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers.Phanquyen
{
    public class UserRoleController : Controller
    {
		// GET: Admin/UserRole
		UsersDAO dao = new UsersDAO();
		UserRoleDAO roledao = new UserRoleDAO();
		public ActionResult Index()
        {
			var Id = Session["IDUser"].ToString();
			var IDPermision = dao.GetByIDPermision(int.Parse(Id)).ToString();
			var Permision = dao.GetPermision(int.Parse(IDPermision));
			ViewBag.Permision = Permision;
			return View();
        }
		[HttpPost]
		public JsonResult GetList()
		{
			var lst = roledao.GetList();
			return Json(new { data = lst }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetUsersRoleById(int id)
		{
			var lst = roledao.GetById(id);
			return Json(lst, JsonRequestBehavior.AllowGet);
		}


		public ActionResult Save(UserRole item)
		{
			bool status = false;
			roledao.Save(item);
			return new JsonResult { Data = new { status = status } };

		}

		public JsonResult Delete(int id)
		{
			var lst = roledao.Delete(id);
			return Json(lst, JsonRequestBehavior.AllowGet);
		}
	}
}