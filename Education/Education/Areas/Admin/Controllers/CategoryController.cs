﻿
using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Education.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        CategoryDAO dao = new CategoryDAO();
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        public ActionResult Index()
        {
			if (Session["Username"].ToString() != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}


        public JsonResult GetCategory()
        {
            var category = dao.GetList();
            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var item = dao.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(Category item)
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
            Category item = dao.GetById(id) as Category;
            item.IsDelete = true;
            dao.Save(item);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}