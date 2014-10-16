using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Blog.Core.Services;
using Domain.Blog.Core.CustomServices;
using Domain.Blog.Entity.Entry;
using Blog.Models;
using AutoMapper;

namespace Blog.Controllers
{
    public class EntryController : Controller
    {
 
		#region properties
		private HomeService ServiceProvider { get; set;}
		#endregion

        public ActionResult Index()
        {
            return RedirectToAction("AddEntry");
        }

		[HttpGet]
		public ActionResult AddEntry()
		{
			return View(new EntryModel());
		}

		[HttpPost]
		public ActionResult AddEntry(EntryModel model)
		{
			if (false == ModelState.IsValid)
			{
				return RedirectToAction("AddEntry");
			}
			var request = Mapper.Map<EntryModel, AddEntryRequest>(model);
			ServiceProvider.AddEntry(request);
			return View();
		}
	}
}
