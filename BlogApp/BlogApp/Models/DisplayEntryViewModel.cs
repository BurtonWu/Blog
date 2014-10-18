using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
	public class DisplayEntryViewModel
	{
		public List<List<String>> Entries { get; set; } 
		#region ctor
		public DisplayEntryViewModel(List<List<String>> Entries)
		{
			this.Entries = Entries;
		}
		#endregion
	}
}