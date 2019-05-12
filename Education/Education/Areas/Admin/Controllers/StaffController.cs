using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
	public class StaffController : BaseController
	{
		StaffDAO dao = new StaffDAO();
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		// GET: Admin/Staff
		public ActionResult Index()
		{
			var staffs = dao.GetList();
			ViewBag.staffs = staffs;
			return View();
		}
		public JsonResult GetStaff()
		{
			var staffs = dao.GetList();
			return Json(new { data = staffs }, JsonRequestBehavior.AllowGet);

		}
		public JsonResult GetStaffById(int id)
		{
			var staffs = dao.GetStaffById(id);
			return Json(staffs, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Save(Staff item)
		{
			bool status = false;
			dao.Save(item);
			return new JsonResult { Data = new { status = status } };
		}
		public JsonResult Delete(int id)
		{
			Staff item = dao.GetStaffById(id) as Staff;
			item.IsDelete = true;
			dao.Save(item);
			return Json(item, JsonRequestBehavior.AllowGet);
		}
	}
}