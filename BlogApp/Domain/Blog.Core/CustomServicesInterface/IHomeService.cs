using Domain.Blog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Blog.Core.CustomServicesInterface
{
	public interface IHomeService
	{
		List<List<String>> getEntriesList();
	}
}
