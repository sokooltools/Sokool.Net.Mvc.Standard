using System.Web.Optimization;

namespace Sokool.Net.Web
{
	public static class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/content/scripts/jquery-{version}.js"
			));
			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/content/scripts/jquery.validate*"
			));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/content/scripts/modernizr").Include(
				"~/content/scripts/modernizr-*"
			));
			bundles.Add(new ScriptBundle("~/content/scripts/bootstrap").Include(
				"~/content/scripts/bootstrap.js"
			));
			bundles.Add(new ScriptBundle("~/content/scripts/_site").Include(
				"~/content/scripts/_site.js"
			));
			bundles.Add(new StyleBundle("~/content/css/bootstrap").Include(
				"~/content/css/bootstrap.css"
			));
			bundles.Add(new StyleBundle("~/content/css/fontawesome").Include(
				"~/content/css/font-awesome.css"
			));
			bundles.Add(new StyleBundle("~/content/css/site").Include(
				"~/content/css/site.css"
			));
		}
	}
}
