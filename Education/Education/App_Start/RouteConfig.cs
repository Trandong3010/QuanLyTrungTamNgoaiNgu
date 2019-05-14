using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Education
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home_", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				 name: "TrangChu",
				 url: "trang-chu",
				 defaults: new { Controller = "~/Home_", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "LienHe",
				url: "lien-he",
				defaults: new { controller = "~/Contact_", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
