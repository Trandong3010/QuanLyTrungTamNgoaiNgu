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

		[HttpGet]
		public JsonResult ShowMenuAdmin()
		{
			int x = 0;
			if (Session["RoleName"].ToString() == "AD" || Session["RoleName"].ToString() == "MA")
			{
				x = 1;
			}
			else if (Session["RoleName"].ToString() == "TE" || Session["RoleName"].ToString() == "AD" || Session["RoleName"].ToString() == "MA")
			{
				x = 2;
			}
			else if (Session["RoleName"].ToString() == "EM" || Session["RoleName"].ToString() == "AD" || Session["RoleName"].ToString() == "MA")
			{
				x = 3;
			}
			return Json(x, JsonRequestBehavior.AllowGet);
		}
	}
}