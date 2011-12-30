using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorProjectERPRec.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			//ViewBag.Message = "Welcome to ASP.NET MVC!";
			return RedirectToAction("Index", "Dashboard");
			//return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
