using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
	public class StudentController : BaseController
	{
		StudentDAO dao = new StudentDAO();
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		// GET: Admin/TaiKhoan
		public ActionResult Index()
		{
			var students = dao.GetList();
			ViewBag.students = students;
			return View();
		}

		public JsonResult GetStudent()
		{
			var students = dao.GetList();
			return Json(new { data = students }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetStudentsById(int id)
		{
			var students = dao.GetStudentById(id);
			return Json(students, JsonRequestBehavior.AllowGet);
		}


		public ActionResult Save(Student item)
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
	}
}