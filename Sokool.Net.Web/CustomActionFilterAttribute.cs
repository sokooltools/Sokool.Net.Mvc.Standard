using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace Sokool.Net.Web
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public sealed class CustomActionFilterAttribute : FilterAttribute, IActionFilter
	{
		private readonly string _location;

		public CustomActionFilterAttribute(string location)
		{
			_location = location;
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
			string action = filterContext.ActionDescriptor.ActionName;
			DateTime dt = filterContext.HttpContext.Timestamp;
			//string ip = filterContext.HttpContext.Request.UserHostAddress;
			Trace.TraceInformation($"{dt} [OnActionExecuting] Controller={controller}, Action={action}, Location={_location}" );
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
			string action = filterContext.ActionDescriptor.ActionName;
			DateTime dt = filterContext.HttpContext.Timestamp;
			Trace.TraceInformation($"{dt} [OnActionExecuted]  Controller={controller}, Action={action}, Location={_location}" );
		}
	}
}