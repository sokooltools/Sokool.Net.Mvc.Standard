using System.Linq;
using System.Web.Mvc;
using Sokool.Net.DataLibrary.Data;
using Sokool.Net.Web.Models;

namespace Sokool.Net.Web.Controllers
{
    public class PhotosController : BaseController
    {
	    [HttpGet]
	    public ActionResult Photos1(int? id = 0)
	    {
		    return View("Photos1", GetPhotosModel(id));
	    }

	    [HttpGet]
	    public ActionResult Photos2(int? id = 0)
	    {
		    return View("Photos2", GetPhotosModel(id));
	    }

	    private static IOrderedEnumerable<Photo> GetPhotosModel(int? id)
	    {
		    string folder = "~/assets/photos/";
		    switch (id)
		    {
			    case 0:
				    break;
			    case 1:
				    folder += "cameras/";
				    break;
			    case 2:
				    folder += "cars/";
				    break;
			    case 3:
				    folder += "ships/";
				    break;
			    case 4:
				    folder += "021310/";
				    break;
		    }
		    return new PhotosModel(folder, ".jpg").ToList().OrderBy(m=>m.Path);
	    }
    }
}