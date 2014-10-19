using Domain.Blog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Blog.Entity.Entry;

namespace Domain.Blog.Core.CustomServicesInterface
{
	public interface IHomeService
	{
		List<AddEntryRequest> getEntriesList();
		
	}
}
