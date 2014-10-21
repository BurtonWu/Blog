using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Blog.Entity.Entry;
using Domain.Blog.Core.Pager;

namespace BlogApp.Models.Home
{
	public class DisplayEntryViewModel : PagedList<AddEntryRequest>
	{
		#region ctor
		public DisplayEntryViewModel(IEnumerable<AddEntryRequest> entries, Int32 pageNumber, Int32 pageSize) :
			base(entries, pageNumber, pageSize)
		{
		}
		public DisplayEntryViewModel()
		{
		}
		#endregion
	}
}