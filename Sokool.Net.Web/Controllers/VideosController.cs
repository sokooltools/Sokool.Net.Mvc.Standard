using System.Linq;
using System.Web.Mvc;
using Sokool.Net.DataLibrary.Data;
using Sokool.Net.Web.Models;

namespace Sokool.Net.Web.Controllers
{
    public class VideosController : BaseController
    {
	    [HttpGet]
	    public ActionResult Index(string vf, string ext = ".mp4")
	    {
		    return View(new VideosModel(vf, ext).ToList().OrderBy(m=>m.Name));
	    }

	    [HttpGet]
	    public ActionResult Show(string vf = @"Across", string fn = "Hey Jude.mp4")
	    {
		    string virtualFolderPath =  $@"~/assets/videos/{vf}/";
			string physicalFilePath = System.Web.HttpContext.Current.Server.MapPath(virtualFolderPath) + fn;
		    return View(new Video(virtualFolderPath, physicalFilePath));
	    }
	}
}