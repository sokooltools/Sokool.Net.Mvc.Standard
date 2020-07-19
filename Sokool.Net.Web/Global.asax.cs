using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Sokool.Net.Web.Controllers;

namespace Sokool.Net.Web
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		protected void Application_Error()
		{
			Exception ex = Server.GetLastError();
			Context.Response.Clear();
			Context.ClearError();
			RequestContext requestContext = ((MvcHandler)Context.CurrentHandler).RequestContext;
			if (requestContext.HttpContext.Request.IsAjaxRequest())
			{
				Context.Response.Write("Ajax request failed due to server error!");
				Context.Response.End();
			}
			else
			{
				var routeData = new RouteData();
				routeData.Values["controller"] = "ErrorHandler";
				routeData.Values["action"] = "InternalException";
				routeData.Values.Add("url", Context.Request.Url.OriginalString);
				routeData.Values.Add("exception", ex);
				//var httpException = ex as HttpException;
				//if (httpException != null)
				//{
				//	switch (httpException.GetHttpCode())
				//	{
				//		case 404:
				//			routeData.Values["action"] = "NotFound";
				//			break;
				//		case 403:
				//			routeData.Values["action"] = "GenericError";
				//			break;
				//		case 500:
				//			routeData.Values["action"] = "InternalException";
				//			break;
				//	}
				//}
				IController controller = new ErrorHandlerController();
				controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
			}
		}
	}
}
