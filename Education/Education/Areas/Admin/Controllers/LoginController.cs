using Education.DAO;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Education.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		UsersDAO userdao = new UsersDAO();
		
		// GET: Admin/Login
		public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public JsonResult CheckUsername(string Username)
		{
			System.Threading.Thread.Sleep(200);
			bool result = false;
			var lst = db.Users.Where(x => x.Username == Username).SingleOrDefault();
			if(lst != null)
				result = true;
			return Json(result, JsonRequestBehavior.AllowGet);
		}
		[HttpPost]
		public ActionResult CheckValidaUser(User model)
		{
			bool result = false;
			var DataItem = db.Users.Where(x => x.Username == model.Username && x.Password == model.Password).SingleOrDefault();
			
			if (DataItem != null)
			{
				var RoleName = userdao.GetByIDRole(int.Parse(DataItem.IDRole));
				//Session["RoleName"] = DataItem.IDRole.ToString();

				Session["RoleName"] = RoleName;
				Session["IDUser"] = DataItem.ID.ToString();
				Session["Username"] = DataItem.Username.ToString();
				result = true;
			}
			else
			{
				result = false;
			}
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult CheckRole()
		{
			if (Session["IDUser"] != null)
			{
				return RedirectToAction("Index", "Admin/TrangChu");
			}
			else
			{
				return RedirectToAction("Index", "Admin/Login");
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