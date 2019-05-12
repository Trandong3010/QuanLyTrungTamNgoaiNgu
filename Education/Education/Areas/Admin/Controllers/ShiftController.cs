using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
	public class ShiftController : BaseController
	{
		//
		// GET: /Admin/Shift/
		ShiftDAO dao = new ShiftDAO();
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		public ActionResult Index()
		{
			var shifts = dao.GetList();
			ViewBag.shifts = shifts;
			return View();
		}

		public JsonResult GetShifts()
		{
			var shifts = dao.GetList();
			return Json(new { data = shifts }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetShiftById(int id)
		{
			var shifts = dao.GetShiftById(id);
			return Json(shifts, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Save(Shift item)
		{
			bool status = false;
			if (item.ID == 0)
			{
				item.CreateTime = DateTime.Now;
			}
			dao.Save(item);
			return new JsonResult { Data = new { status = status } };

		}

		public JsonResult Delete(int id)
		{
			var lst = dao.Delete(id);
			return Json(lst, JsonRequestBehavior.AllowGet);
		}
	}
}
