using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Blog.Core.Services;
using Domain.Blog.Core.CustomServices;
using Domain.Blog.Entity.Entry;
using AppBlog.Models;
using AutoMapper;

namespace BlogApp.Controllers
{
	public class EntryController : Controller
	{

		#region properties
		private EntryService ServiceProvider { get; set; }
		#endregion

		public EntryController()
		{
			ServiceProvider = new EntryService();
		}


		[HttpGet]
		[Route("~/AddEntry")]
		public ActionResult AddEntry()
		{
			return View(new AddEntryViewModel());
		}

		[HttpPost]
		[Route("~/AddEntry")]
		public ActionResult AddEntry(AddEntryViewModel model)
		{
			if (false == ModelState.IsValid)
			{
				Response.Write("bad");
				return RedirectToAction("AddEntry");
			}
			//find some other method for this instead of assembly usage?
			model.createMap();
			var request = Mapper.Map<AddEntryViewModel, AddEntryRequest>(model);
			ServiceProvider.AddEntry(request);
			Response.Write("added");

			return View();
		}
	}
}
