using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Blog.Core.Services;
using Domain.Blog.Entity.Entry;

namespace Domain.Blog.Core.CustomServices
{
    public class HomeService
    {
        #region constants
        #endregion

        #region ctor
        public HomeService()
        {
        }
        #endregion

        #region Add Entry
        public Boolean AddEntry(AddEntryRequest entry)
        {
			using (DataContext dbContext = new DataContext())
			{
				dbContext.Entries.Add(entry);
				dbContext.SaveChanges();
			}
            return false;
        }
        #endregion
    }
}
