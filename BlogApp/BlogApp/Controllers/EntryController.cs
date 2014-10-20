﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Blog.Core.Services;
using Domain.Blog.Core.CustomServicesInterface;
using Domain.Blog.Entity.Entry;
using BlogApp.Models;
using AutoMapper;

namespace BlogApp.Controllers
{
	public class EntryController : Controller
	{

		#region properties
		private IEntryService ServiceProvider { get; set; }
		#endregion

		public EntryController()
		{
			ServiceProvider = new ServiceProviders();
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
			//model.createMap();
			var request = Mapper.Map<AddEntryViewModel, AddEntryRequest>(model);
			ServiceProvider.addEntry(request);
			Response.Write("added");

			return RedirectToAction("Index", "Home");
		}

		#region EditEntry
		[HttpGet]
		public ActionResult EditEntry(Int32 Id)
		{
			return View(new EditEntryViewModel(ServiceProvider.getSingleEntry(Id)));
		}

		[HttpPost]
		public ActionResult EditEntry(EditEntryViewModel model)
		{
			//model.createMap();
			var request = Mapper.Map<EditEntryViewModel, EditEntryRequest>(model);
			ServiceProvider.editEntry(request);
			return RedirectToAction("Index", "Home");
		}
		#endregion

		#region RemoveEntry
		[HttpPost]
		public ActionResult RemoveEntry(Int32 Id)
		{
			ServiceProvider.removeEntry(Id);
			return JavaScript("location.reload(true)");
		}
		#endregion
	}
}
