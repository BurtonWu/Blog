using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Blog.Core.CustomServicesInterface;
using Domain.Blog.Entity.Entry;

namespace Domain.Blog.Core.Services
{
	public class ServiceProviders : IEntryService, IHomeService
	{
		#region getEntriesList
		List<List<String>> IHomeService.getEntriesList()
		{
			var entries = new List<List<String>>();
			var Id = getIdList();
			var title = getTitlesList();
			var date = getDatesList();
			var passage = getPassagesList();
			for (int i = 0; i < title.Count; i++)
			{
				entries.Add(new List<String>() { Id[i].ToString(), title[i], date[i].ToString(), passage[i] });
			}
			return entries;
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

		#region getSingleEntry
		List<String> IEntryService.getSingleEntry(Int32 Id)
		{
			using (DataContext dbcontext = new DataContext())
			{
				var entity = dbcontext.Entries.Single(x => x.Id == Id);
				return new List<String>() { entity.Id.ToString(), entity.Title, entity.Passage, entity.Date.ToString() };
			}
		}
		#endregion

		#region helperMethods
		#region getIdList
		public List<Int32> getIdList()
		{
			using (DataContext dbcontext = new DataContext())
			{
				return dbcontext.Entries.Select(x => x.Id).ToList();
			}
		}
		#endregion

		#region getPassageList
		public List<String> getPassagesList()
		{
			using (DataContext dbcontext = new DataContext())
			{
				return dbcontext.Entries.Select(x => x.Passage).ToList();
			}
		}
		#endregion

		#region getDateList
		public List<DateTime> getDatesList()
		{
			using (DataContext dbcontext = new DataContext())
			{
				return dbcontext.Entries.Select(x => x.Date).ToList();
			}
		#endregion
		}

		#region getTitlesList
		public List<String> getTitlesList()
		{
			using (DataContext dbcontext = new DataContext())
			{
				return dbcontext.Entries.Select(x => x.Title).ToList();
			}
		}
		#endregion
		#endregion
	}
}
