using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    public class CoureController : Controller
    {
        // GET: Admin/Coure
        CoureDAO dao = new CoureDAO();
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        // GET: Admin/Staff
        public ActionResult Index()
        {
            var coures = dao.GetList();
            ViewBag.coure = coures;
            return View();
        }
        public JsonResult GetCoure()
        {
            var coure = dao.GetList();
            return Json(new { data = coure }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetCoureById(int id)
        {
            var coures = dao.GetCoursesById(id);
            return Json(coures, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(Course item)
        {
            bool status = false;
            dao.Save(item);
            return new JsonResult { Data = new { status = status } };
        }
        public JsonResult Delete(int id)
        {
            Course item = dao.GetCoursesById(id) as Course;
            item.IsDelete = true;
            dao.Save(item);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}