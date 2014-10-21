using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Blog.Core.Services;
using Domain.Blog.Core.CustomServicesInterface;
using BlogApp.Models.Comment;
using AutoMapper;
using Domain.Blog.Entity.Comment;
using Domain.Blog.Entity.Entry;

namespace BlogApp.Controllers
{
    public class CommentController : Controller
    {
		public ICommentService ServiceProviders { get; set; }

		public CommentController()
		{
			ServiceProviders = new ServiceProviders();
		}
		[HttpGet]
        public ActionResult Index(Int32 Id)
        {
			var request = new CommentViewModel();
			request = Mapper.Map<List<AddCommentRequest>, CommentViewModel>(ServiceProviders.getCommentsList(Id));
			request.Entry = ServiceProviders.getSingleEntry(Id);
			request.EntryId = Id;
            return View(request);
        }

		[HttpPost]
		public ActionResult AddComment(CommentViewModel model)
		{
			if (true == ModelState.IsValid)
			{
				var request = Mapper.Map<CommentViewModel, AddCommentRequest>(model);
				ServiceProviders.addComment(request);
			}
			return RedirectToAction("Index", new { Id = model.EntryId });
		}

		[HttpPost]
		public ActionResult RemoveComment(Int32 Id)
		{
			ServiceProviders.removeComment(Id);
			return JavaScript("location.reload(true)");
		}
    }
}
