using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Blog.Core.Services;
using Domain.Blog.Entity.Entry;

namespace Domain.Blog.Core.CustomServices
{
	public class EntryService
	{

		#region ctor
		public EntryService()
		{
		}
		#endregion

		#region Add Entry
		public void AddEntry(AddEntryRequest entry)
		{
			using (DataContext dbContext = new DataContext())
			{
				dbContext.Entries.Add(entry);
				dbContext.SaveChanges();
			}
		}
		#endregion
	}
}
