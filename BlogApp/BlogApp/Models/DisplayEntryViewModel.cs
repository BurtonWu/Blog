using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Blog.Entity.Entry;

namespace BlogApp.Models
{
	public class DisplayEntryViewModel
	{
		public List<AddEntryRequest> Entries { get; set; } 
		#region ctor
		public DisplayEntryViewModel(List<AddEntryRequest> Entries)
		{
			this.Entries = Entries;
		}
		#endregion
	}
}