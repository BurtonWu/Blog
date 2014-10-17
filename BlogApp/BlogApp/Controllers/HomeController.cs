using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Blog.Core.Services;
using Domain.Blog.Core.CustomServices;
using BlogApp.Models;

namespace BlogApp.Controllers
{
	public class HomeController : Controller
	{

		#region properties
		private HomeService ServiceProvider { get; set; }
		#endregion

		#region ctor
		public HomeController()
		{
			//Start up database
			new DataContext().Entries.FirstOrDefault();
			ServiceProvider = new HomeService();
		}
		#endregion

		[HttpGet]
		[Route("~/Blog")]
		public ActionResult Home()
		{
			return View(new DisplayEntryViewModel(ServiceProvider.displayEntries()));
		}
	}
}
