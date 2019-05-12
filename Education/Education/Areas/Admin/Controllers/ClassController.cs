using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    public class ClassController : BaseController
    {
        //
        // GET: /Admin/Class/
        ClassDAO dao = new ClassDAO();
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        public ActionResult Index()
        {
            var classes = dao.GetList();
            ViewBag.classes = classes;
			if (Session["Username"].ToString() != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
        }

        public JsonResult GetClass()
        {
            var classes = dao.GetList();
            return Json(new { data = classes }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetClassById(int id)
        {
            var classes = dao.GetClassById(id);
            return Json(classes, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(Class item)
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