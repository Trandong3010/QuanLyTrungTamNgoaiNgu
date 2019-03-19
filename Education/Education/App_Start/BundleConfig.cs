using System.Web;
using System.Web.Optimization;

namespace Education
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{



			//-------------------------------- Css and Javascript ----------------------------------------------//
			bundles.Add(new ScriptBundle("~/bundles/javascript/Back-end").Include(
						"~/Content/Back-end/vendor/jquery/jquery.min.js",
						"~/Content/Back-end/vendor/bootstrap/js/bootstrap.min.js",
						"~/Content/Back-end/vendor/metisMenu/metisMenu.js",
						"~/Content/Back-end/vendor/datatables/js/jquery.dataTables.min.js",
						"~/Content/Back-end/vendor/datatables-plugins/dataTables.bootstrap.min.js",
						"~/Content/Back-end/vendor/datatables-responsive/dataTables.responsive.js",
						"~/Content/Back-end/dist/js/admin.js"
						));
			bundles.Add(new StyleBundle("~/Content/css/Back-end").Include(
					  "~/Content/Back-end/vendor/bootstrap/css/bootstrap.min.css",
					  "~/Content/Back-end/vendor/metisMenu/metisMenu.css",
					  "~/Content/Back-end/vendor/datatables-plugins/dataTables.bootstrap.css",
					  "~/Content/Back-end/vendor/datatables-responsive/dataTables.responsive.css",
					  "~/Content/Back-end/dist/css/admin.css",
					  "~/Content/Back-end/vendor/font-awesome/css/font-awesome.min.css"
					  ));
			//-------------------------------- Css end Javascript ----------------------------------------------//

			//-------------------------------- Css and Javascript ----------------------------------------------//
			bundles.Add(new ScriptBundle("~/bundles/javascript/Front-end").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new StyleBundle("~/Content/css/Front-end").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css"));
			//-------------------------------- Css end Javascript ----------------------------------------------//

			//bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
			//			"~/Scripts/jquery-{version}.js"));

			//bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
			//			"~/Scripts/jquery.validate*"));

			//// Use the development version of Modernizr to develop with and learn from. Then, when you're
			//// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			//bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
			//			"~/Scripts/modernizr-*"));

			//bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
			//		  "~/Scripts/bootstrap.js",
			//		  "~/Scripts/respond.js"));

			//bundles.Add(new StyleBundle("~/Content/css").Include(
			//		  "~/Content/bootstrap.css",
			//		  "~/Content/site.css"));
		}
	}
}
