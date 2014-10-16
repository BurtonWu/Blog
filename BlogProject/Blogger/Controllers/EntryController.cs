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

		public EntryController()
		{
			ServiceProvider = new HomeService();
		}

		
		[HttpGet]
		//[Route("~/AddEntry")]
		public ActionResult AddEntry()
		{
			return View(new EntryModel());
		}

		[HttpPost]
		public ActionResult AddEntry(EntryModel model)
		{
			if (false == ModelState.IsValid)
			{
				Response.Write("bad");
				return RedirectToAction("AddEntry");
			}
			//find some other method for this instead of assembly usage?
			model.createMap();
			var request = Mapper.Map<EntryModel, AddEntryRequest>(model);
			ServiceProvider.AddEntry(request);
			Response.Write("added");

			return View();
		}
	}
}
