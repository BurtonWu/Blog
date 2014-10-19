using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Blog.Core.CustomServicesInterface;
using Domain.Blog.Entity.Entry;
using Domain.Blog.Entity.Comment;

namespace Domain.Blog.Core.Services
{
	public class ServiceProviders : IEntryService, IHomeService, ICommentService
	{
		#region IHomeService
		#region getEntriesList
		List<AddEntryRequest> IHomeService.getEntriesList()
		{
			using (DataContext dbcontext = new DataContext())
			{
				return dbcontext.Entries.ToList();
			}
		}
		#endregion
		#endregion

		#region IEntryService
		#region RemoveEntry
		void IEntryService.RemoveEntry(Int32 Id)
		{
			using (DataContext dbContext = new DataContext())
			{
				dbContext.Entries.Remove(dbContext.Entries.Single(x => x.Id == Id));
				dbContext.Comments.RemoveRange(dbContext.Comments.Where(x => x.EntryId == Id));
				dbContext.SaveChanges();
				
			}
		}
		#endregion

		#region AddEntry
		void IEntryService.AddEntry(AddEntryRequest entry)
		{
			using (DataContext dbContext = new DataContext())
			{
				dbContext.Entries.Add(entry);
				dbContext.SaveChanges();
			}
		}
		#endregion

		#region EditEntry
		void IEntryService.EditEntry(EditEntryRequest model)
		{
			using (DataContext dbContext = new DataContext())
			{
				var changeEntry = dbContext.Entries.Single(x => x.Id == model.Id);
				changeEntry.Title = model.Title;
				changeEntry.Passage =  model.Passage;
				changeEntry.Date = DateTime.UtcNow.AddHours(-4);
				dbContext.SaveChanges();
			}
		}
		#endregion

		#region getEntryInformation
		List<String> IEntryService.getEntryInformation(Int32 Id)
		{
			using (DataContext dbcontext = new DataContext())
			{
				var entity = dbcontext.Entries.Single(x => x.Id == Id);
				return new List<String>() { entity.Id.ToString(), entity.Title, entity.Passage, entity.Date.ToString() };
			}
		}
		#endregion
		#endregion

		#region ICommentService
		#region getSingleEntry
		AddEntryRequest ICommentService.getSingleEntry(Int32 Id)
		{
			using (DataContext dbcontext = new DataContext())
			{
				return dbcontext.Entries.Single(x => x.Id == Id);
			}
		}
		#endregion

		#region getCommentsList
		List<AddCommentRequest> ICommentService.getCommentsList(Int32 Id)
		{
			using (DataContext dbcontext = new DataContext())
			{
				return dbcontext.Comments.Where(x => x.EntryId == Id).ToList();
			}
		}
		#endregion

		#region AddComment
		void ICommentService.AddComment(AddCommentRequest request)
		{
			using (DataContext dbcontext = new DataContext())
			{
				dbcontext.Comments.Add(request);
				dbcontext.SaveChanges();
			}
		}
		#endregion
		#endregion

	}
}
