using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Blog.Core.Services;

namespace Blog.Controllers
{
	public class HomeController : Controller
	{

		#region properties

		#endregion
		public HomeController() { }

		public ActionResult Home()
		{
			//Start up database
			//new DataContext().Entries.FirstOrDefault();
			return View();
		}
	}
}
