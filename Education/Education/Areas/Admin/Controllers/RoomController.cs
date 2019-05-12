using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
	public class RoomController : BaseController
	{
		//
		// GET: /Admin/Room/
		RoomDAO dao = new RoomDAO();
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		public ActionResult Index()
		{
			var rooms = dao.GetList();
			ViewBag.rooms = rooms;
			return View();
		}

		public JsonResult GetRoom()
		{
			var rooms = dao.GetList();
			return Json(new { data = rooms }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetRoomById(int id)
		{
			var rooms = dao.GetRoomById(id);
			return Json(rooms, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Save(Room item)
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