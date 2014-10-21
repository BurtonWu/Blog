using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Blog.Core.Services;
using Domain.Blog.Core.CustomServicesInterface;
using Domain.Blog.Entity.Entry;
using BlogApp.Models.Entry;
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
			if (true == ModelState.IsValid)
			{
				var request = Mapper.Map<AddEntryViewModel, AddEntryRequest>(model);
				ServiceProvider.addEntry(request);
				Response.Write("added");
				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("AddEntry");
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
			if (true == ModelState.IsValid)
			{
				var request = Mapper.Map<EditEntryViewModel, EditEntryRequest>(model);
				ServiceProvider.editEntry(request);
				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("EditEntry", new { Id = model.ReplaceThisEntry.Id });
		}
		#endregion

		#region removeEntry

		[HttpGet]
		public ActionResult RemoveEntry(Int32 Id)
		{
			ServiceProvider.removeEntry(Id);
			return RedirectToAction("Index", "Home");
		}
		#endregion
	}
}
