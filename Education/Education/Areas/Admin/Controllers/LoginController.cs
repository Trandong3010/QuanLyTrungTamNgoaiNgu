using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		// GET: Admin/Login
		public ActionResult Index()
        {
            return View();
        }

		public JsonResult CheckUsername(string Username)
		{
			System.Threading.Thread.Sleep(200);
			bool result = false;
			var lst = db.Users.Where(x => x.Username == Username).SingleOrDefault();
			if(lst != null)
				result = true;
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult CheckValidaUser(User model)
		{
			string result = "Fail";
			var DataItem = db.Users.Where(x => x.Username == model.Username && x.Password == model.Password).SingleOrDefault();
			if (DataItem.Username != null && DataItem.Password != null)
			{
				Session["Role"] = DataItem.Role.ToString();
				Session["Username"] = DataItem.Username.ToString();
				result = "Success";
			}
			else
			{

			}
			return Json(result, JsonRequestBehavior.DenyGet);
		}

		public ActionResult CheckRole()
		{
			if (Session["Role"] != null)
			{
				return RedirectToAction("Index", "TrangChu");
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		public ActionResult Logout()
		{
			Session.Clear();
			Session.Abandon();
			return RedirectToAction("Index", "Admin/Login");
		}
	}
}