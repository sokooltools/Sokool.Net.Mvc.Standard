using System;
using System.Net;
using System.Web.Mvc;
using Sokool.Net.Web.Models;

namespace Sokool.Net.Web.Controllers
{
	public class SamplesController : BaseController
	{
		[HttpGet]
		public ActionResult Samples1()
		{
			const string virtualFolder = "~/samples/";
			const string extension = ".htm";
			return View(new SamplesModel(virtualFolder, extension));
		}

		[HttpGet]
		public ActionResult Samples2()
		{
			const string virtualFolder = "~/views/samples/";
			const string extension = ".cshtml";
			return View(new SamplesModel(virtualFolder, extension));
		}

		[HttpGet]
		public ActionResult ReadFile()
		{
			return View();
		}

		[HttpGet]
		public ActionResult BadRequest() // 400
		{
			Response.StatusCode = (int) HttpStatusCode.BadRequest;
			return new EmptyResult();
		}

		[HttpGet]
		public ActionResult Unauthorized() // 401
		{
			Response.StatusCode = (int) HttpStatusCode.Unauthorized;
			return new EmptyResult();
		}

		[HttpGet]
		public ActionResult RequestTimeout() // 408
		{
			Response.StatusCode = (int) HttpStatusCode.RequestTimeout;
			return new EmptyResult();
		}

		[HttpGet]
		public ActionResult Unavailable() // 503
		{
			Response.StatusCode = (int) HttpStatusCode.ServiceUnavailable;
			return new EmptyResult();
		}

		[HttpGet]
		public ActionResult NullReferenceException() // 500
		{
			string msg = null;
			// ReSharper disable once PossibleNullReferenceException
			ViewBag.Message = msg.Length; // This will throw an exception
			return new EmptyResult();
		}

		[HttpGet]
		//[HandleError(Order = 1, View = "DivideByZero", ExceptionType = typeof(DivideByZeroException))]
#pragma warning disable CA1822 // Mark members as static
		public ActionResult DivideByZeroException()
#pragma warning restore CA1822 // Mark members as static
		{
			int i = 10;
			// ReSharper disable once IntDivisionByZero
			i /= 0; // This will throw an exception
			Console.WriteLine(i);
			return new EmptyResult();
		}
	}
}