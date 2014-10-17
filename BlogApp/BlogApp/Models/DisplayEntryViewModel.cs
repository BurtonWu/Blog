using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
	public class DisplayEntryViewModel
	{
		public List<String> Passages { get; set; }

		#region ctor
		public DisplayEntryViewModel(List<String> Passages)
		{
			this.Passages = Passages;
		}
		#endregion
	}
}