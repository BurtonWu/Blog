﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Blog.Core.Services;
using Domain.Blog.Core.CustomServicesInterface;
using BlogApp.Models.Home;
using Domain.Blog.Entity.Entry;

namespace BlogApp.Controllers
{
	public class HomeController : Controller
	{

		#region properties
		private IHomeService ServiceProvider { get; set; }
		#endregion

		#region ctor
		public HomeController()
		{
			//Start up database
			new DataContext().Entries.FirstOrDefault();
			ServiceProvider = new ServiceProviders();
		}
		#endregion

		[HttpGet]
		[Route("~/Blog")]
		public ActionResult Index(Int32 pageNumber = 1)
		{
			return View(new DisplayEntryViewModel(ServiceProvider.getEntriesList(), pageNumber, 5));
		}
	}
}
