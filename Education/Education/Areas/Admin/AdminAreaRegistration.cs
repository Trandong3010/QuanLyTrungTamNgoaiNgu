using System.Web.Mvc;

namespace Education.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }


        public override void RegisterArea(AreaRegistrationContext context) 
        {
			//context.MapRoute(
			//	name: "Default",
			//	url: "{controller}/{action}/{id}",
			//	defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			//);
			context.MapRoute(
                 "TaiKhoan",
                 "Admin/TaiKhoan",
                  new { Controller = "TaiKhoan", action = "Index", id = UrlParameter.Optional }
			);

			context.MapRoute(
				"UserRole",
				"Admin/UserRole",
			   new { Controller = "UserRole", action = "Index", id = UrlParameter.Optional }
			);

			context.MapRoute(
				"Student",
				"Admin/Student",
			   new { Controller = "Student", action = "Index", id = UrlParameter.Optional }
			);

			context.MapRoute(
                "Shift",
                "Admin/Shift",
               new { Controller = "Shift", action = "Index", id = UrlParameter.Optional }
            );

			context.MapRoute(
			   "Admin_default",
				"Admin/{controller}/{action}/{id}",
			   new { Controller = "Login", action = "index", id = UrlParameter.Optional }
           );

			context.MapRoute(
				"Dashboard",
				"Admin/Dashboard",
				new { Controller = "Trangchu/TrangChu", action = "Index", id = UrlParameter.Optional }
			);

        }

    }
}
