using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Blog.Entity.Entry;

namespace Domain.Blog.Core.Services
{
	public class DataContext : DbContext
	{
		public DataContext()
			: base("Test")
		{

		}
		public DbSet<AddEntryRequest> Entries { get; set; }
	}
}
