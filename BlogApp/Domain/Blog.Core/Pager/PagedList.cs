using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Blog.Core.Pager
{
	public class PagedList<TEntity>
	{
		public Int32 PageNumber { get; set; }
		public Int32 PageSize { get; set; }
		public Int32 TotalPages { get; set; }
		public List<TEntity> SortedEntities { get; set; }

		public PagedList(IEnumerable<TEntity> entities, Int32 pageNumber, Int32 pageSize)
		{
			if (pageSize > 0) this.PageSize = pageSize; else this.PageSize = 5;
			
			this.SortedEntities = new List<TEntity>();
			this.TotalPages = (Int32)Math.Ceiling(entities.Count() / (Double)this.PageSize);

			if (pageNumber > this.TotalPages) this.PageNumber = this.TotalPages; else this.PageNumber = pageNumber;

			this.SortedEntities = (entities.Skip((this.PageNumber -1) * this.PageSize).Take(this.PageSize).ToList());
		}
		public PagedList() { }
	}
}
