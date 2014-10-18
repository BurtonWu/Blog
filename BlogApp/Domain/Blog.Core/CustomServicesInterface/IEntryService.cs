using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Blog.Core.Services;
using Domain.Blog.Entity.Entry;

namespace Domain.Blog.Core.CustomServicesInterface
{
	public interface IEntryService
	{
		void AddEntry(AddEntryRequest entry);
		List<String> getSingleEntry(Int32 Id);
		void EditEntry(EditEntryRequest model);
	}
}
