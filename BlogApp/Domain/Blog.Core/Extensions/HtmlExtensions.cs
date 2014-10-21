using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Domain.Blog.Core.Extensions
{
	public static class HtmlExtensions
	{
		public static IHtmlString PageLoader<TEntity>(this HtmlHelper html, List<TEntity> entities)
		{
			return html.Partial("Entries", entities);
		}

	}
}
