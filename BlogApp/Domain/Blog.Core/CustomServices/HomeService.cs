using Domain.Blog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Blog.Core.CustomServices
{
	public class HomeService
	{

		#region displayEntries
		public List<String> displayEntries()
		{
			using(DataContext dbcontext = new DataContext())
			{
				return dbcontext.Entries.Select(x => x.Passage).ToList();
			}
		}
		#endregion
	}
}
