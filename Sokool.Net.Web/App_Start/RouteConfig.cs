using System.Web.Mvc;
using System.Web.Routing;

namespace Sokool.Net.Web
{
	public static class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


			routes.MapRoute(
				name: "Videos",
				url: "Videos/{action}/{vf}",
				defaults: new { controller = "Videos", action = "Index", vf = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "HelloWorld",
				url: "HelloWorld/{action}/{name}/{id}",
				defaults: new { controller = "HelloWorld", action = "Index", id = UrlParameter.Optional },
				constraints: new { id = @"\d+" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
